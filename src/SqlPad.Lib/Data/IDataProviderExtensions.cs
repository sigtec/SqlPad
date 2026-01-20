namespace SqlPad.Lib.Data
{
  using SqlPad.Data.Contracts;
  using System.Data;
    using System.Data.Common;
    using System.Globalization;
    using System.Text.RegularExpressions;

  public static class IDataProviderExtensions
  {
    static readonly Regex paramAnnotationRegex = new(@"^\s*--!Param\s+(?<name>\w+)\s+(?:(?<direction>In|Out|In Out|Input|Output|InputOutput|ReturnValue)\s+)?(?<type>\w+)(?:\s*=\s*(?<value>.*))?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    static readonly Regex commandTypeAnnotationRegex = new(@"^--!(?<type>StoredProcedure|TableDirect)(?:\s+)(?<name>.+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static DbCommand CreateCommandAndParseAnnotation(this IDataProvider provider, string commandText)
    {
      var command = provider.CreateCommand(); 
      command.CommandText = commandText;


      foreach (var line in commandText.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries))
      {
        var paramMatch = paramAnnotationRegex.Match(line);
        if (paramMatch.Success)
        {
          var paramName = paramMatch.Groups["name"]?.Value ?? throw new InvalidOperationException("Parameter name is missing in annotation.");
          var paramDirection = paramMatch.Groups["direction"]?.Value;
          var paramType = paramMatch.Groups["type"]?.Value;
          var paramValue = paramMatch.Groups["value"]?.Value;
          var direction = paramDirection?.ToUpperInvariant() switch
          {
            "IN" => ParameterDirection.Input,
            "OUT" => ParameterDirection.Output,
            "IN OUT" => ParameterDirection.InputOutput,
            null => ParameterDirection.Input,
            "" => ParameterDirection.Input,
            _ => Enum.Parse<ParameterDirection>(paramDirection, true)
          };
          var parameter = provider.CreateParameter(paramName, null, direction, paramType);
          if (!string.IsNullOrWhiteSpace(paramValue))
          {
            paramValue = paramValue.Trim();
            if (!paramValue.Equals("NULL", StringComparison.InvariantCultureIgnoreCase))
            {
              if (paramValue.Length > 2 && paramValue.StartsWith("'") && paramValue.EndsWith("'"))
              {
                // trim off first and last single bracket, but only one!
                paramValue = paramValue[1..^1];
              }
              parameter.Value = parameter.DbType switch
              {
                DbType.Int32 => int.Parse(paramValue, CultureInfo.InvariantCulture),
                DbType.Decimal => decimal.Parse(paramValue, CultureInfo.InvariantCulture),
                DbType.Date or DbType.DateTime => DateTime.Parse(paramValue, CultureInfo.InvariantCulture),
                _ => paramValue
              };
            }
          }
          command.Parameters.Add(parameter);
        }
        paramMatch = commandTypeAnnotationRegex.Match(line);
        if (paramMatch.Success)
        {
          var paramType = paramMatch.Groups["type"].Value;
          var paramName = paramMatch.Groups["name"].Value;
          command.CommandType = Enum.Parse<CommandType>(paramType, true);
          command.CommandText = paramName.Trim();
        }
      }
      return command;
    }
  }
}

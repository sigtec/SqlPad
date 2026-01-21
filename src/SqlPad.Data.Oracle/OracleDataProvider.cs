namespace SqlPad.Data.Oracle
{
  using global::Oracle.ManagedDataAccess.Client;
  using SqlPad.Data.Contracts;
  using System.Data;
  using System.Data.Common;
    using System.Globalization;
    using System.Net;

  public class OracleDataProvider : IDataProvider
  {
    public const int ORACLE_VARCHAR_MAX_BUFFER_SIZE = 32767;

    readonly OracleConnection _connection = new OracleConnection();

    public ConnectionState ConnectionState => _connection.State;

    public bool SupportsNamedParameters => true;

    public bool SupportsUsernamePassword => true;

    public char ParameterPrefix => ':';

    public event EventHandler<InfoMessageEventArgs>? InfoMessage;

    public DbTransaction BeginTransaction() => _connection.BeginTransaction();

    public void Connect(string connectionString, NetworkCredential? credential)
    {
      if (credential is not null)
      {
        var connectionStringBuilder = new OracleConnectionStringBuilder(connectionString)
        {
          UserID = credential.UserName,
          Password = credential.Password
        };
        _connection.ConnectionString = connectionStringBuilder.ConnectionString;
      }
      else
      {
        _connection.ConnectionString = connectionString;
      }
      _connection.InfoMessage += (_, e) =>
      {
        foreach (OracleError error in e.Errors)
        {
          InfoMessage?.Invoke(this, new InfoMessageEventArgs
          {
            Number = error.Number,
            Message = error.Message,
            Offset = error.ParseErrorOffset,
            Procedure = error.Procedure,
            Index = error.ArrayBindIndex
          });
        }
      };
      _connection.Open();
      // activate DBMS_OUTPUT
      using (var command = _connection.CreateCommand())
      {
        command.CommandText = "ALTER SESSION SET PLSQL_WARNINGS='ENABLE:ALL'";
        command.ExecuteNonQuery();
        command.CommandText = "BEGIN DBMS_OUTPUT.ENABLE(NULL); END;";
        command.ExecuteNonQuery();
      }
    }

    public DbCommand CreateCommand()
    {
      var command = _connection.CreateCommand();
      command.InitialLONGFetchSize = -1; // fetch full LONG and LONG RAW by default
      command.BindByName = true; // bind parameters by name
      // add event handler to collect DBMS_OUTPUT messages
      command.Disposed += (_, _) =>
      {
        CollectDbmsOutputMessages();
      };

      return command;
    }

    public IDataParameter CreateParameter(string name, object? value, ParameterDirection direction = ParameterDirection.Input, string? type = null)
    {
      var parmeter = new OracleParameter
      {
        ParameterName = name,
        Value = value ?? DBNull.Value,
        Direction = direction
      };
      if (!string.IsNullOrEmpty(type))
      {
        if (Enum.TryParse<OracleDbType>(type, true, out var orcaclelDbType))
        {
          parmeter.OracleDbType = orcaclelDbType;
        }
        else if (Enum.TryParse<DbType>(type, true, out var dbType))
        {
          parmeter.DbType = dbType;
        }
        else
        {
          throw new ArgumentException($"Unsupported parameter type '{type}' for SQL Server data provider.");
        }
      }
      // set buffer size for Oracle output parameters
      if (direction == ParameterDirection.Output || direction == ParameterDirection.InputOutput)
      {
        switch (parmeter.OracleDbType)
        {
          case OracleDbType.Varchar2:
          case OracleDbType.NVarchar2:
          case OracleDbType.Char:
          case OracleDbType.NChar:
            parmeter.Size = ORACLE_VARCHAR_MAX_BUFFER_SIZE;
            break;
        }
      }
      return parmeter;
    }

    public void Dispose() => _connection.Dispose();

    public NetworkCredential? GetCredential(string connectionString)
    {
      var connectionStringBuilder = new OracleConnectionStringBuilder(connectionString);
      return new NetworkCredential(connectionStringBuilder.UserID, connectionStringBuilder.Password);
    }

    public string GetSqlLiteral(object? value)
    {
      if (value == null || value == DBNull.Value)
      {
        return "NULL";
      }
      else if (value is bool b)
      {
        return b ? "1" : "0";
      }
      else if (value is string s)
      {
        return $"'{s.Replace("'", "''")}'";
      }
      else if (value is DateTime dt)
      {
        return $"TO_TIMESTAMP('{dt.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}', 'YYYY-MM-DD HH24:MI:SS.FF3')";
      }
      else if (value is IFormattable formattable)
      {
        return formattable.ToString(null, CultureInfo.InvariantCulture);
      }

      return $"'{value.ToString()?.Replace("'", "''")}'";
    }

    private void CollectDbmsOutputMessages()
    {
      try
      {
        using var command = _connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "DBMS_OUTPUT.GET_LINE";
        var lineParameter = new OracleParameter("line", OracleDbType.Varchar2, ORACLE_VARCHAR_MAX_BUFFER_SIZE)
        {
          Direction = ParameterDirection.Output
        };
        var statusParameter = new OracleParameter("status", OracleDbType.Int32)
        {
          Direction = ParameterDirection.Output
        };
        command.Parameters.Add(lineParameter);
        command.Parameters.Add(statusParameter);
        while (true)
        {
          command.ExecuteNonQuery();
          if ($"{statusParameter.Value}" != "0")
          {
            break;
          }
          InfoMessage?.Invoke(this, new InfoMessageEventArgs
          {
            Message = $"{lineParameter.Value}"
          });
        }
      }
      catch (Exception ex)
      {
        InfoMessage?.Invoke(this, new InfoMessageEventArgs
        {
          Message = $"Failed to collect DBMS_OUTPUT messages: {ex.Message}"
        });
      }
    }
  }
}

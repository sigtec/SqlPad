namespace SqlPad.Data.SqlServer
{
  using Microsoft.Data.SqlClient;
  using SqlPad.Data.Contracts;
  using System.Data;
  using System.Data.Common;
  using System.Globalization;
  using System.Net;

  public class SqlServerDataProvider : IDataProvider
  {

    readonly SqlConnection _connection = new SqlConnection();
    public bool SupportsNamedParameters => true;

    public bool SupportsUsernamePassword => true;

    public char ParameterPrefix => '@';

    public ConnectionState ConnectionState => _connection.State;

    public event EventHandler<InfoMessageEventArgs>? InfoMessage;

    public IDbTransaction BeginTransaction() => _connection.BeginTransaction();

    public void Connect(string connectionString, NetworkCredential? credential)
    {
      if (credential is not null)
      {
        var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString)
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
        foreach (SqlError error in e.Errors)
        {
          InfoMessage?.Invoke(this, new InfoMessageEventArgs
          {
            Number = error.Number,
            Message = error.Message,
            LineNumber = error.LineNumber,
            State = error.State,
            Procedure = error.Procedure,
          });
        }
      };
      _connection.Open();
    }

    public IDbCommand CreateCommand() => _connection.CreateCommand();

    public IDataParameter CreateParameter(string name, object? value, ParameterDirection direction = ParameterDirection.Input, string? type = null)
    {
      var parmeter = new SqlParameter
      {
        ParameterName = name,
        Value = value ?? DBNull.Value,
        Direction = direction
      };
      if (!string.IsNullOrEmpty(type))
      {
        if (Enum.TryParse<SqlDbType>(type, true, out var sqlDbType))
        {
          parmeter.SqlDbType = sqlDbType;
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
      return parmeter;
    }

    public void Dispose() => _connection.Dispose();

    public NetworkCredential? GetCredential(string connectionString)
    {
      var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
      return new NetworkCredential(connectionStringBuilder.UserID, connectionStringBuilder.Password);
    }

    DbTransaction IDataProvider.BeginTransaction() => _connection.BeginTransaction();

    DbCommand IDataProvider.CreateCommand() => _connection.CreateCommand();
  }
}

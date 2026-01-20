namespace SqlPad.DataAccess
{
  using SqlPad.Data.Contracts;
  using System.Data;
  using System.Data.Common;
  using System.Net;

  public class ConnectionManager : IDataProvider
  {
    readonly IDataProvider _dataProvider;
    public ConnectionManager(DataProviderName dataProvider)
    {
      DataProviderName = dataProvider;
      _dataProvider = dataProvider switch
      {
        DataProviderName.SqlServer => new SqlPad.Data.SqlServer.SqlServerDataProvider(),
        DataProviderName.Oracle => new SqlPad.Data.Oracle.OracleDataProvider(),
        _ => throw new NotSupportedException($"Data provider {dataProvider} is not supported.")
      };
    }

    public DataProviderName DataProviderName { get; }

    public ConnectionState ConnectionState => _dataProvider.ConnectionState;

    public bool SupportsNamedParameters => _dataProvider.SupportsNamedParameters;

    public bool SupportsUsernamePassword => _dataProvider.SupportsUsernamePassword;

    public char ParameterPrefix => _dataProvider.ParameterPrefix;

    public event EventHandler<InfoMessageEventArgs>? InfoMessage
    {
      add
      {
        _dataProvider.InfoMessage += value;
      }

      remove
      {
        _dataProvider.InfoMessage -= value;
      }
    }

        public DbTransaction BeginTransaction() => _dataProvider.BeginTransaction();

        public void Connect(string connectionString, NetworkCredential? credential) => _dataProvider.Connect(connectionString, credential);

        public DbCommand CreateCommand() => _dataProvider.CreateCommand();

        public IDataParameter CreateParameter(string name, object? value, ParameterDirection direction = ParameterDirection.Input, string? type = null) => _dataProvider.CreateParameter(name, value, direction, type);

        public void Dispose() => _dataProvider.Dispose();

        public NetworkCredential? GetCredential(string connectionString) => _dataProvider.GetCredential(connectionString);
    }
}

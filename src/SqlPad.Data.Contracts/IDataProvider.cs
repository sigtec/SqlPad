namespace SqlPad.Data.Contracts
{
  using System.Data;
  using System.Data.Common;
  using System.Net;

  public interface IDataProvider : IDisposable
  {
    void Connect(string connectionString, NetworkCredential? credential);

    ConnectionState ConnectionState { get; }

    DbTransaction BeginTransaction();
    DbCommand CreateCommand();
    IDataParameter CreateParameter(string name, object? value, ParameterDirection direction = ParameterDirection.Input, string? type = default);

    bool SupportsNamedParameters { get; }
    bool SupportsUsernamePassword { get; }

    char ParameterPrefix { get; }

    event EventHandler<InfoMessageEventArgs>? InfoMessage;

    NetworkCredential? GetCredential(string connectionString);
  }
}

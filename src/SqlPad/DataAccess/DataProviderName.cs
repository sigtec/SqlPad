namespace SqlPad.DataAccess
{
  using System.Text.Json.Serialization;

  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum DataProviderName
  {
    SqlServer,
    Oracle,
    PostgreSql,
    MySql,
    SQLite,
    ISeries
  }
}

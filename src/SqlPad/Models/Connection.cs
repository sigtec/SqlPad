namespace SqlPad.Models
{
  using SqlPad.DataAccess;

  public class Connection
  {
    public string Name { get; set; }
    public DataProviderName DataProvider { get; set; }
    public required string ConnectionString { get; set; }
    public bool AskForCredentials { get; set; }

    public override string ToString() => this.Name;
  }
}

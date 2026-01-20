namespace SqlPad.Models
{
  public class Project
  {
    public string? Name { get; set; } = null;
    public List<Connection> Connections { get; set; } = new List<Connection>();
  }
}

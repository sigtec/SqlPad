namespace SqlPad.Data.Contracts
{
  public class InfoMessageEventArgs : EventArgs, IInfoMessage
  {
    public int? Number { get; init; }
    public required string Message { get; init; }
    public int? LineNumber { get; init; }
    public int? State { get; init; }
    public string? Procedure { get; init; }
    public int? Offset { get; init; }
    public int? Index { get; init; }
  }
}

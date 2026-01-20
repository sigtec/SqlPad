namespace SqlPad.Data.Contracts
{
  public interface IInfoMessage
  {
    int? Number { get; }
    string Message { get; }
    int? LineNumber { get; }
    int? State { get; }
    string? Procedure { get; }
    int? Offset { get; }
    int? Index { get; }
  }
}

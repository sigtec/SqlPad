using SqlPad.Data.Contracts;
using System.Collections;

namespace SqlPad.DataAccess
{
  public class MessageRetriever : IDisposable, IEnumerable<IInfoMessage>
  {
    readonly IDataProvider _dataProvider;
    readonly Queue<IInfoMessage> _messages = new Queue<IInfoMessage>();
    public MessageRetriever(IDataProvider dataProvider)
    {
      _dataProvider = dataProvider;
      _dataProvider.InfoMessage += DataProvider_InfoMessage;
    }

    private void DataProvider_InfoMessage(object? sender, InfoMessageEventArgs e)
    {
      _messages.Enqueue(e);
    }

    public void Dispose()
    {
      _dataProvider.InfoMessage -= DataProvider_InfoMessage;
    }

    public IEnumerator<IInfoMessage> GetEnumerator()
    {
      while (_messages.Count > 0)
      {
        yield return _messages.Dequeue();
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}

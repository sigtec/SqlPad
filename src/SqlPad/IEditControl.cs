namespace SqlPad
{
  public interface IEditControl
  {
    void Cut();
    void Copy();
    void Paste();
    void SelectAll();
    void Delete();
    void Undo();
    void Redo();
    void ShowFindDialog();
    void ShowReplaceDialog();
  }
}

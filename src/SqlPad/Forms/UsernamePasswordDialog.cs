namespace SqlPad.Forms
{
  using System.ComponentModel;

  public partial class UsernamePasswordDialog : Form
  {
    public UsernamePasswordDialog()
    {
      InitializeComponent();
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string UserName
    {
      get => textBoxUserName.Text;
      set => textBoxUserName.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Password
    {
      get => textBoxPassword.Text;
      set => textBoxPassword.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool RememberCredentials
    {
      get => checkBoxRememberCredentials.Checked;
      set => checkBoxRememberCredentials.Checked = value;
    }

  }
}

using Microsoft.Win32;
using SqlPad.DataAccess;
using SqlPad.Models;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SqlPad.Forms
{
  public partial class MainForm : Form
  {
    public string[] CommandLineArgs { get; }
    public ConnectionManager? ConnectionManager { get; private set; }
    public Project? Project { get; private set; }
    public static readonly SHA256 sha256 = SHA256.Create();
    public static readonly RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(@"Software\SqlPad\StoredCredentials");
    
    public MainForm(string[] commandLineArgs)
    {
      InitializeComponent();
      CommandLineArgs = commandLineArgs;
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      if (this.CommandLineArgs.Length > 0)
      {

        // called with directoryname as argument
        var di = new DirectoryInfo(this.CommandLineArgs[0]);
        if (di.Exists)
        {
          LoadProject(di);
          return;
        }


        var fi = new FileInfo(this.CommandLineArgs[0]);
        if (!fi.Exists)
        {
          LoadProject(fi);
          return;
        }

        MessageBox.Show(this, "The specified file does not exist: " + fi.FullName, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        Close();
        return;
      }

      // default behavior: load project for current directory
      LoadProject(new DirectoryInfo(Environment.CurrentDirectory));
    }

    private void LoadProject(FileInfo fi)
    {
      var json = File.ReadAllText(fi.FullName);
      this.Project = JsonSerializer.Deserialize<Project>(json) ?? throw new Exception("Project deserialization failed.");


      if (string.IsNullOrEmpty(this.Project.Name))
      {
        this.Project.Name = fi.Directory!.Name;
      }

      // read files
      var treeNode = new TreeNode(Project!.Name) { Tag = fi.Directory };
      // dummy
      treeNode.Nodes.Add(new TreeNode(string.Empty));
      treeViewFiles.Nodes.Add(treeNode);
      treeNode.Expand();

      // populate Connections
      toolStripComboBoxConnection.Items.AddRange(Project.Connections.ToArray());
      toolStripComboBoxConnection.SelectedIndex = 0;
      if (this.Project.Connections.Count == 1)
      {
        toolStripButtonConnect.PerformClick();
      }
    }

    private void LoadProject(DirectoryInfo di)
    {
      var fi = new FileInfo(Path.Combine(di.FullName, "SqlPad.project.json"));
      if (fi.Exists)
      {
        LoadProject(fi);
      }
      else
      {
        MessageBox.Show(this, $"The folder \"{di.FullName}\" does not contain a SqlPad.project.json");
      }
    }

    private bool OpenDatabaseConnection()
    {
      var connectionItem = toolStripComboBoxConnection.SelectedItem as Connection;

      if (connectionItem == null)
      {
        MessageBox.Show(this, "No connection selected.");
        return false;
      }


      this.ConnectionManager = new ConnectionManager(connectionItem.DataProvider);
      NetworkCredential? credential = null;
      if (connectionItem.AskForCredentials)
      {
        credential = this.ConnectionManager.GetCredential(connectionItem.ConnectionString);

        var hash = Convert.ToHexString(sha256.ComputeHash(Encoding.UTF8.GetBytes(connectionItem.ConnectionString)));
        var salt = sha256.ComputeHash(Encoding.UTF8.GetBytes($"salt:{connectionItem.ConnectionString}"));
        var restoredCredentials = false;
        if (registryKey.GetValue(hash) is byte[] crypt)
        {
          var plain = ProtectedData.Unprotect(crypt, salt, DataProtectionScope.CurrentUser);
          var tokens = Encoding.UTF8.GetString(plain).Split('\n');
          if(tokens.Length == 2)
          {
            credential = new NetworkCredential(tokens[0], tokens[1]);
            restoredCredentials = true;
          }
        }

        using (var dlg = new UsernamePasswordDialog()
        {
          UserName = credential?.UserName ?? string.Empty,
          Password = credential?.Password ?? string.Empty,
          RememberCredentials = restoredCredentials
        })
        {
          if (dlg.ShowDialog(this) == DialogResult.OK)
          {
            credential = new NetworkCredential(dlg.UserName, dlg.Password);
          }
          else
          {
            return false;
          }


          if (dlg.RememberCredentials)
          {
            var plain = Encoding.UTF8.GetBytes($"{dlg.UserName}\n{dlg.Password}");
            crypt = ProtectedData.Protect(plain, salt, DataProtectionScope.CurrentUser);
            registryKey.SetValue(hash, crypt);
          }
          else
          {
            registryKey.DeleteValue(hash, throwOnMissingValue: false);
          }
        }
      }
      this.ConnectionManager.Connect(connectionItem.ConnectionString, credential);

      //propertyGridParameters.SelectedObject = this.ConnectionManager;
      return true;
    }

    private void treeViewFiles_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
      if (e.Node?.Tag is DirectoryInfo di)
      {
        e.Node.Nodes.Clear();
        // Subdirectories
        foreach (var subdir in di.GetDirectories())
        {
          var subdirNode = new TreeNode(subdir.Name)
          {
            Tag = subdir,
            ImageKey = "FolderClosed.png",
            SelectedImageKey = "FolderClosed.png"
          };
          // dummy
          subdirNode.Nodes.Add(new TreeNode(string.Empty));
          e.Node.Nodes.Add(subdirNode);
        }
        // Files 
        foreach (var file in di.GetFiles("*.sql"))
        {
          var fileNode = new TreeNode(file.Name)
          {
            Tag = file,
            ImageKey = "TextFile.png",
            SelectedImageKey = "TextFile.png",
            StateImageKey = file.IsReadOnly ? "Lock.png" : String.Empty
          };
          e.Node.Nodes.Add(fileNode);
        }
      }
    }

    private void treeViewFiles_AfterCollapse(object sender, TreeViewEventArgs e)
    {
      if (e.Node?.Tag is DirectoryInfo)
      {
        // cleanup nodes, add dummy node again
        e.Node.Nodes.Clear();
        e.Node.Nodes.Add(new TreeNode(string.Empty));
        // set closed icon
        e.Node.ImageKey = "FolderClosed.png";
        e.Node.SelectedImageKey = "FolderClosed.png";
      }
    }

    private void treeViewFiles_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(e.Label))
        {
          e.CancelEdit = true;
        }
        else if (e.Node?.Tag == null)
        {
          // create new file
          if (e.Node?.Parent?.Tag is DirectoryInfo diParent)
          {
            var filename = e.Label!.Trim();
            if (!filename.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
            {
              filename += ".sql";
            }
            var fi = new FileInfo(Path.Combine(diParent.FullName, filename));
            if (fi.Exists)
            {
              throw new InvalidOperationException("File already exists.");
            }

            // create physical file
            File.WriteAllText(fi.FullName, string.Empty);

            e.Node.Text = fi.Name;
            e.Node.Tag = fi;
            e.Node.ImageKey = "TextFile.png";
            e.Node.SelectedImageKey = "TextFile.png";
          }
        }
        else if (e.Node?.Tag is DirectoryInfo di)
        {
          di.MoveTo(Path.Combine(di.Parent!.FullName, e.Label.Trim()));
        }
        else if (e.Node?.Tag is FileInfo fi)
        {
          var filename = e.Label!.Trim();
          if (!filename.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
          {
            filename += ".sql";
          }
          fi.MoveTo(Path.Combine(fi.Directory!.FullName, filename));
          // rename open editor form
          var documentForm = this.MdiChildren
          .OfType<EditorForm>()
          .FirstOrDefault(f => f.FileInfo == fi);
          if (documentForm != null)
          {
            documentForm.Text = documentForm.FileInfo.Name;
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, ex.Message, "Error Renaming File or Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
        e.CancelEdit = true;
      }
    }

    private void treeViewFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        treeViewFiles.SelectedNode = e.Node;
        if (e.Node?.Tag is DirectoryInfo)
        {
          contextMenuTreeViewDirectoryNodes.Show(treeViewFiles, e.Location);
        }
        if (e.Node?.Tag is FileInfo)
        {
          contextMenuTreeViewFileNodes.Show(treeViewFiles, e.Location);
        }
      }
    }
    private void toolStripMenuItemReload_Click(object sender, EventArgs e)
    {
      if (treeViewFiles.SelectedNode?.Tag is DirectoryInfo di)
      {
        // recreate DirectoryInfo, as it may have changed
        treeViewFiles.SelectedNode.Tag = new DirectoryInfo(di.FullName);
      }
      treeViewFiles.SelectedNode?.Collapse();
      treeViewFiles.SelectedNode?.Expand();
    }

    private void treeViewFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      if (e.Node?.Tag is FileInfo fi)
      {
        // try to activate existing editor form
        var documentForm = this.MdiChildren
          .OfType<EditorForm>()
          .FirstOrDefault(f => f.FileInfo == fi);
        if (documentForm != null)
        {
          //restore if minimized
          if (documentForm.WindowState == FormWindowState.Minimized)
          {
            documentForm.WindowState = FormWindowState.Normal;
          }
          documentForm.Activate();
          return;
        }

        // new editor form
        documentForm = new EditorForm()
        {
          FileInfo = fi,
          ConnectionManager = this.ConnectionManager,
          MdiParent = this
        };
        documentForm.Show();
      }
    }

    private void treeViewFiles_AfterExpand(object sender, TreeViewEventArgs e)
    {
      if (e.Node?.Tag is DirectoryInfo)
      {
        // set expanded icon
        e.Node.ImageKey = "FolderOpened.png";
        e.Node.SelectedImageKey = "FolderOpened.png";
      }
    }

    private void openInWindowsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (treeViewFiles.SelectedNode?.Tag is DirectoryInfo di)
      {
        Process.Start(new ProcessStartInfo
        {
          FileName = di.FullName,
          UseShellExecute = true
        });
      }
    }

    private void addNewFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (treeViewFiles.SelectedNode == null)
      {
        return;
      }
      var newItem = treeViewFiles.SelectedNode.Nodes.Add(String.Empty);
      newItem.BeginEdit();
    }

    private void toolStripButtonConnect_Click(object sender, EventArgs e)
    {
      try
      {
        if (!toolStripButtonConnect.Checked)
        {
          OpenDatabaseConnection();
          toolStripButtonConnect.Checked = true;
        }
        else
        {
          this.ConnectionManager?.Dispose();
          this.ConnectionManager = null;
          toolStripButtonConnect.Checked = false;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void toolStripButtonConnect_CheckedChanged(object sender, EventArgs e)
    {
      toolStripComboBoxConnection.Enabled = !toolStripButtonConnect.Checked;
    }

    private void openInTerminalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (treeViewFiles.SelectedNode?.Tag is DirectoryInfo directoryInfo)
        {
          Process.Start(new ProcessStartInfo
          {
            FileName = Environment.GetEnvironmentVariable("COMSPEC"),
            Arguments = $"/K cd /d \"{directoryInfo.FullName}\"",
            UseShellExecute = true
          });
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}

namespace SqlPad.Forms
{
  using SqlPad.DataAccess;
  using System.ComponentModel;
  using System.Data;
  using System.Diagnostics;
  using System.Text;
  using SqlPad.Lib.Data;

  public partial class EditorForm : Form
  {
    //TODO: Replace with https://github.com/megakraken/ICSharpCode.TextEditor

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public required FileInfo FileInfo { get; init; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public required ConnectionManager? ConnectionManager { get; init; }

    public readonly StringBuilder Messages = new StringBuilder();

    private CancellationTokenSource? cancellationTokenSource = null;
    public EditorForm()
    {
      InitializeComponent();
    }

    private void EditorForm_Shown(object sender, EventArgs e)
    {
      this.Text = this.FileInfo?.Name;
      if (this.FileInfo == null)
      {
        return;
      }
      using (var stream = this.FileInfo.OpenRead())
      {
        using (var reader = new StreamReader(stream))
        {
          editorTextBox.Text = reader.ReadToEnd();
        }
      }
      editorTextBox.ReadOnly = this.FileInfo.IsReadOnly;
      if (editorTextBox.ReadOnly)
      {
        editorTextBox.BackColor = SystemColors.Control;
      }
      this.toolStripButtonRun.Enabled = (this.ConnectionManager?.ConnectionState == ConnectionState.Open);
    }

    private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      Process.Start(new ProcessStartInfo
      {
        FileName = e.LinkText,
        UseShellExecute = true
      });
    }

    private void editorTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Control)
      {
        toolStripButtonRun.PerformClick();
        e.Handled = true;
      }
      else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
      {
        toolStripButtonRun.PerformClick();
        e.Handled = true;
      }
    }

    private async void toolStripButtonRun_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.cancellationTokenSource != null)
        {
          if (MessageBox.Show(this, "A query is already running. Do you want to cancel it?", "Cancel Query", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
          {
            return;
          }
          this.cancellationTokenSource?.Cancel();
          return;
        }

        var sqlText = editorTextBox.SelectedText;
        if (string.IsNullOrWhiteSpace(sqlText))
        {
          MessageBox.Show(this, "No SQL selected to execute.", "Execute SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }

        toolStripButtonRun.Checked = true;

        this.Cursor = Cursors.AppStarting;
        var resultSetControls = new List<UserControls.ResultSetControl>();

        using (var messageRetriever = new MessageRetriever(ConnectionManager!))
        {
          using (var command = ConnectionManager!.CreateCommandAndParseAnnotation(sqlText))
          {
            textBoxMessages.Clear();
            Messages.Clear();

            tabControl.TabPages.Clear();
            tabControl.TabPages.Add(tabPageMessages);
            this.Update();
            Application.DoEvents();

            var limit = toolStripButtonLimit.Checked ? int.Parse(toolStripTextBoxLimitRows.Text) : int.MaxValue;

            var stopwatch = Stopwatch.StartNew();
            using (var transaction = toolStripButtonUseTransaction.Checked ? ConnectionManager!.BeginTransaction() : null)
            {
              command.Transaction = transaction;
              this.cancellationTokenSource = new CancellationTokenSource();

              var resultSetIndex = 0;
              var queryStatus = new QueryStatus();
              await foreach (var dataTable in command.ExecuteQueryAsync(this.cancellationTokenSource.Token, limit, queryStatus))
              {
                if (dataTable.Columns.Count > 0)
                {
                  var name = $"ResultSet{++resultSetIndex}";
                  var resultSetControl = new UserControls.ResultSetControl
                  {
                    Name = name,
                    Dock = DockStyle.Fill,
                    DataTable = dataTable
                  };
                  var tabPage = new TabPage(name);
                  tabPage.Controls.Add(resultSetControl);
                  tabControl.TabPages.Add(tabPage);
                  resultSetControls.Add(resultSetControl);
                  Application.DoEvents();
                }
                else
                {
                  Messages.AppendLine($"{queryStatus.RecordsAffected} row(s) affected.");
                }
              }

              foreach (var resultSetControl in resultSetControls)
              {
                Messages.AppendLine($"{resultSetControl.Name}: {resultSetControl.DataTable.Rows.Count} row(s) loaded.");
                foreach (var group in resultSetControl.DataErrors.GroupBy(x => (x.col, x.ex.Message)))
                {
                  var name = resultSetControl.DataTable.Columns[group.Key.col].ColumnName;
                  Messages.AppendLine($"Data Error in {resultSetControl.Name}, Column {name}: {group.Key.Message}");
                }
              }

              stopwatch.Stop();
              this.Cursor = Cursors.Default;
              if (transaction != null)
              {
                if (MessageBox.Show(this, "The execution completed successfully. The transaction will be committed now.", "Transaction Commit", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                  transaction.Commit();
                  Messages.AppendLine("Transaction committed.");
                }
                else
                {
                  transaction.Rollback();
                  Messages.AppendLine("Transaction rolled back by user.");
                }
              }
            }

            foreach (var param in command.Parameters.OfType<IDataParameter>())
            {
              Messages.AppendLine($"Parameter Name={param.ParameterName}, Direction={param.Direction}, Type={param.DbType}, Value={param.Value}");
            }
            Messages.AppendLine($"Execution completed in {stopwatch.Elapsed}.");
          }
          // retrieve info messages after command is disposed, as 
          // DBMS_OUTPUT messages in Oracle are only available then
          foreach (var message in messageRetriever)
          {
            if (this.cancellationTokenSource?.IsCancellationRequested ?? true)
            {
              break;
            }
            Messages.Append(message.Message);
            if (message.Number is not null)
            {
              Messages.Append($"{nameof(message.Number)}={message.Number} ");
            }
            if (message.Index is not null)
            {
              Messages.Append($"{nameof(message.Index)}={message.Index} ");
            }
            if (message.Procedure is not null)
            {
              Messages.Append($"{nameof(message.Procedure)}={message.Procedure} ");
            }
            if (message.Offset is not null)
            {
              Messages.Append($"{nameof(message.Offset)}={message.Offset} ");
            }
            if (message.State is not null)
            {
              Messages.Append($"{nameof(message.State)}={message.State} ");
            }
            Messages.AppendLine();

            tabControl.SelectedTab = tabControl.TabPages.Cast<TabPage>().LastOrDefault();

            foreach (var resultSetControl in resultSetControls)
            {
              if (this.cancellationTokenSource?.IsCancellationRequested ?? true)
              {
                break;
              }
              resultSetControl.AutoResizeColumns();
            }
          }
        }
      }
      catch (TaskCanceledException)
      {
        Messages.AppendLine("Execution cancelled by user.");
      }
      catch (Exception? ex)
      {
        while (ex != null)
        {
          Messages.AppendLine($"Error: {ex.Message}");
          ex = ex.InnerException;
        }
      }
      textBoxMessages.Text = Messages.ToString();
      this.cancellationTokenSource = null;
      toolStripButtonRun.Checked = false;
      this.Cursor = Cursors.Default;
    }

    private void saveCopyAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (var dlg = new SaveFileDialog()
      {
        FileName = this.FileInfo.FullName,
        CheckPathExists = true,
        Filter = "SQL-Files (*.sql)|*.sql|All Files (*.*)|*.*",
        FilterIndex = 0
      })
      {
        if (dlg.ShowDialog() != DialogResult.OK)
        {
          return;
        }
        try
        {
          using (var writer = new StreamWriter(dlg.FileName))
          {
            writer.Write(editorTextBox.Text);
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show(this, $"Error on saving file \"{dlg.FileName}\":\r\n{ex}", "Error on saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void toolStripSplitButtonSave_ButtonClick(object sender, EventArgs e)
    {
      try
      {
        using (var stream = this.FileInfo.OpenWrite())
        {
          using (var writer = new StreamWriter(stream))
          {
            writer.Write(editorTextBox.Text);
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, $"Error on saving file \"{this.FileInfo}\":\r\n{ex}", "Error on saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void toolStripTextBoxLimitRows_KeyPress(object sender, KeyPressEventArgs e)
    {
      // only allow 0..9
      if (e.KeyChar < '0' || e.KeyChar > '9')
      {
        e.Handled = true;
      }
    }

    private void toolStripButtonLimit_CheckedChanged(object sender, EventArgs e)
    {
      toolStripTextBoxLimitRows.Enabled = toolStripButtonLimit.Checked;
    }
  }
}

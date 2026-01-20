namespace SqlPad.UserControls
{
  using ClosedXML.Excel;
  using System.ComponentModel;
  using System.Data;
  using System.Diagnostics;
  using System.Globalization;
  using System.Windows.Forms;

  public partial class ResultSetControl : UserControl
  {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public required DataTable DataTable { get; init; }

    private readonly List<(int row, int col, Exception ex)> dataErrors = new List<(int row, int col, Exception ex)>();
    public IReadOnlyList<(int row, int col, Exception ex)> DataErrors => dataErrors.AsReadOnly();

    public ResultSetControl()
    {
      InitializeComponent();
    }

    public void CopyGridSelectionToClipboard()
    {
      try
      {
        ClipboardManager.CopyDataGridSelection(dataGridView);
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, ex.Message, "Copy to Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void toolStripDropDownButtonSaveResults_Click(object sender, EventArgs e)
    {

    }

    private void excelFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using var saveFileDialog = new SaveFileDialog
      {
        Filter = "Excel Files|*.xlsx",
        Title = "Save Results as Excel File"
      };
      if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
      {
        try
        {
          using (var workbook = new XLWorkbook())
          {
            // Add DataTable as a worksheet
            var worksheet = workbook.Worksheets.Add(DataTable, DataTable.TableName);

            if (DataTable.Rows.Count < 2000)
            {
              // Autofit all columns
              worksheet.Columns().AdjustToContents();
            }

            // Save to file
            workbook.SaveAs(saveFileDialog.FileName);
            // Open Excel
            Process.Start(new ProcessStartInfo
            {
              FileName = saveFileDialog.FileName,
              UseShellExecute = true
            });
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show(this, ex.Message, "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void ResultSetControl_Load(object sender, EventArgs e)
    {
      dataGridView.DataSource = DataTable;
    }

    public void AutoResizeColumns()
    {
      if (this.DataTable.Rows.Count < 2000)
      {
        dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
      }
      dataGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
    }

    private void toolStripButtonCopyToClipboard_Click(object sender, EventArgs e)
    {

    }

    private void dataGridView_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
      {
        CopyGridSelectionToClipboard();
        e.Handled = true;
      }
    }

    private void dataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
    {
      e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    private void toolStripSplitButtonCopy_ButtonClick(object sender, EventArgs e)
    {
      CopyGridSelectionToClipboard();
    }

    private void copyColumnNamesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        ClipboardManager.CopyColumnNames(dataGridView);
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, ex.Message, "Copy to Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      if (e.Exception is not null)
      {
        dataErrors.Add((e.RowIndex, e.ColumnIndex, e.Exception));
      }
    }

    private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      foreach (DataGridViewColumn col in dataGridView.Columns)
      {
        col.DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture;
        switch (Type.GetTypeCode(Nullable.GetUnderlyingType(col.ValueType) ?? col.ValueType))
        {
          case TypeCode.Boolean:
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            break;
          case TypeCode.Byte:
          case TypeCode.SByte:
          case TypeCode.Int16:
          case TypeCode.UInt16:
          case TypeCode.Int32:
          case TypeCode.UInt32:
          case TypeCode.Int64:
          case TypeCode.UInt64:
          case TypeCode.Single:
          case TypeCode.Double:
          case TypeCode.Decimal:
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Format = "0.#############################";
            break;
          case TypeCode.DateTime:
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss.fff";
            break;
          default:
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            break;
        }
      }
    }

    private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.RowIndex < 0)
      {
        return;
      }
      if (e.Button != MouseButtons.Left)
      {
        return;
      }
      if (ModifierKeys.HasFlag(Keys.Shift))
      {
        var minRow = Math.Min(dataGridView.SelectedCells.Cast<DataGridViewCell>().Min(c => c.RowIndex), e.RowIndex);
        var maxRow = Math.Max(dataGridView.SelectedCells.Cast<DataGridViewCell>().Max(c => c.RowIndex), e.RowIndex);
        for (var rowIndex = minRow; rowIndex <= maxRow; rowIndex++)
        {
          for (var colIndex = 0; colIndex < dataGridView.ColumnCount; colIndex++)
          {
            dataGridView.Rows[rowIndex].Cells[colIndex].Selected = true;
          }
        }
      }
      else
      {
        if (!ModifierKeys.HasFlag(Keys.Control))
        {
          dataGridView.ClearSelection();
        }
        for (var colIndex = 0; colIndex < dataGridView.ColumnCount; colIndex++)
        {
          dataGridView.Rows[e.RowIndex].Cells[colIndex].Selected = true;
        }
      }
    }
  }
}


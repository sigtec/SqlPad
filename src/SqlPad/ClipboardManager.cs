namespace SqlPad
{
  using SqlPad.DataAccess;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Text;

  internal static class ClipboardManager
  {
    internal enum GridSelectionCopyFormat
    {
      Default,
      ColumnNames,
    }


    internal static void CopyDataGridSelection(DataGridView grid, DataProviderName dataProviderName)
    {
      var rows = grid.SelectedCells.Cast<DataGridViewCell>()
        .Select(cell => cell.RowIndex)
        .Distinct()
        .OrderBy(r => r)
        .ToList();

      var columns = grid.SelectedCells.Cast<DataGridViewCell>()
        .Select(cell => cell.ColumnIndex)
        .Distinct()
        .OrderBy(r => r)
        .ToList();

      if (grid.SelectedCells.Count == 1)
      {
        var value = grid.SelectedCells[0].FormattedValue?.ToString() ?? String.Empty;
        Clipboard.SetText(value);
        return;
      }

      if (columns.Count == 1)
      {
        // copy comma separated values for single column selection
        var clipboadString = string.Join(", ",
          grid.SelectedCells
          .Cast<DataGridViewCell>()
          .OrderBy(cell => cell.RowIndex)
          .Select(cell => GetSqlLiteral(cell.Value, dataProviderName)));
        Clipboard.SetText(clipboadString);
        return;
      }

      var content = grid.SelectedCells.Cast<DataGridViewCell>()
        .ToDictionary(cell => (cell.RowIndex, cell.ColumnIndex), cell => cell.FormattedValue?.ToString() ?? string.Empty);

      var columnsHeaders = columns.Select(c => grid.Columns[c].HeaderText)
        .ToList();

      string markdown = BuildMarkdown(content, columnsHeaders);
      string html = BuildHtml(content, columnsHeaders);

      var data = new DataObject();
      data.SetData(DataFormats.Html, html);
      data.SetData(DataFormats.Text, markdown);

      Clipboard.SetDataObject(data, true);
    }

    private static string BuildHtml(Dictionary<(int RowIndex, int ColumnIndex), string> content, List<string> columnsHeaders)
    {
      var sb = new StringBuilder();

      sb.AppendLine("<table border='1' cellspacing='0' cellpadding='4'>");
      sb.AppendLine("<thead><tr>");

      foreach (var header in columnsHeaders)
      {
        sb.Append("<th>").Append(HtmlEncode(header)).Append("</th>");
      }

      sb.AppendLine("</tr></thead>");
      sb.AppendLine("<tbody>");

      var rows = content.Keys.Select(k => k.RowIndex).Distinct().OrderBy(r => r);
      var cols = content.Keys.Select(k => k.ColumnIndex).Distinct().OrderBy(c => c);

      foreach (var r in rows)
      {
        sb.AppendLine("<tr>");
        foreach (var c in cols)
        {
          content.TryGetValue((r, c), out var val);
          sb.Append("<td>").Append(HtmlEncode(val ?? String.Empty)).Append("</td>");
        }
        sb.AppendLine("</tr>");
      }

      sb.AppendLine("</tbody></table>");

      return WrapHtmlForClipboard(sb.ToString());

    }

    private static string BuildMarkdown(Dictionary<(int RowIndex, int ColumnIndex), string> content, List<string> columnsHeaders)
    {
      var sb = new StringBuilder();

      // Header row
      sb.Append("|");
      foreach (var header in columnsHeaders)
      {
        sb.Append(" ").Append(header).Append(" |");
      }
      sb.AppendLine();

      // Separator
      sb.Append("|");
      foreach (var header in columnsHeaders)
      {
        sb.Append("---|");
      }
      sb.AppendLine();

      var rows = content.Keys.Select(k => k.RowIndex).Distinct().OrderBy(r => r);
      var cols = content.Keys.Select(k => k.ColumnIndex).Distinct().OrderBy(c => c);

      foreach (var r in rows)
      {
        sb.Append("|");
        foreach (var c in cols)
        {
          content.TryGetValue((r, c), out var val);
          sb.Append(" ").Append((val ?? String.Empty).Replace("\r", "").Replace("\n", " ")).Append(" |");
        }
        sb.AppendLine();
      }

      return sb.ToString();
    }

    private static string WrapHtmlForClipboard(string htmlFragment)
    {
      const string header = """
        Version:0.9
        StartHTML:{0:00000000}
        EndHTML:{1:00000000}
        StartFragment:{2:00000000}
        EndFragment:{3:00000000}
 
        """;

      string html =
          "<html><body><!--StartFragment-->" +
          htmlFragment +
          "<!--EndFragment--></body></html>";

      int startHtml = header.Length;
      int startFragment = html.IndexOf("<!--StartFragment-->", StringComparison.Ordinal) + "<!--StartFragment-->".Length;
      int endFragment = html.IndexOf("<!--EndFragment-->", StringComparison.Ordinal);
      int endHtml = startHtml + html.Length;

      return string.Format(
          header,
          startHtml,
          endHtml,
          startHtml + startFragment,
          startHtml + endFragment
      ) + html;
    }

    private static string HtmlEncode(string text) => System.Net.WebUtility.HtmlEncode(text);

    internal static void CopyColumnNames(DataGridView dataGridView)
    {
      var columnNames = dataGridView.SelectedColumns
        .Cast<DataGridViewColumn>()
        .OrderBy(col => col.Index)
        .Select(col => col.HeaderText)
        .ToList();
      if (columnNames.Count <= 1)
      {
        columnNames = dataGridView.Columns
          .Cast<DataGridViewColumn>()
          .Select(col => col.HeaderText)
          .ToList();
      }
      Clipboard.SetText(string.Join(", ", columnNames));
    }

    private static string GetSqlLiteral(object? value, DataProviderName dataProviderName)
    {
      if (value == null || value == DBNull.Value)
      {
        return "NULL";
      }
      else if (value is bool b)
      {
        return b ? "1" : "0";
      }
      else if (value is string s)
      {
        return $"'{s.Replace("'", "''")}'";
      }
      else if (value is DateTime dt)
      {
        switch (dataProviderName)
        {
          case DataProviderName.SqlServer:
            return $"CONVERT(DATETIME, '{dt.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture)}', 126)";
          case DataProviderName.Oracle:
            return $"TO_TIMESTAMP('{dt.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}', 'YYYY-MM-DD HH24:MI:SS.FF3')";
          default:
            return $"'{dt.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture)}'";

        }
      }
      else if (value is IFormattable formattable)
      {
        return formattable.ToString(null, CultureInfo.InvariantCulture);
      }

      return $"'{value.ToString()?.Replace("'", "''")}'";
    }
  }
}

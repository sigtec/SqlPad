namespace SqlPad.Lib.Data
{
  using System.Data;
  using System.Data.Common;
  using System.Runtime.CompilerServices;

  public static class DbCommandExtensions
  {
    public static async IAsyncEnumerable<DataTable> ExecuteQueryAsync(this DbCommand command, [EnumeratorCancellation] CancellationToken cancellationToken = default, int? rowLimit = default, QueryStatus? queryStatus = default)
    {
      using (DbDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
      {
        do
        {
          var table = new DataTable();

          int fieldCount = reader.FieldCount;
          for (int i = 0; i < fieldCount; i++)
          {
            var name = reader.GetName(i);
            var suffix = 2;
            while(table.Columns.Contains(name))
            {
              name = $"{reader.GetName(i)}#{suffix++}";
            }
            table.Columns.Add(name, reader.GetFieldType(i));
          }

          var rowCount = 0;
          table.BeginLoadData();
          while (await reader.ReadAsync(cancellationToken) && rowCount++ < (rowLimit ?? int.MaxValue))
          {
            object[] rowValues = new object[fieldCount];
            reader.GetValues(rowValues);
            table.LoadDataRow(rowValues, true);
          }
          table.EndLoadData();

          queryStatus?.RecordsAffected = reader.RecordsAffected;

          yield return table;

        } while (await reader.NextResultAsync(cancellationToken));
      }
    }
  }
}


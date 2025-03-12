using System.Text;
using CCG51.DBF.Viewer.Domain.Entities;
using CCG51.DBF.Viewer.Domain.Interfaces;
using CCG51.DBF.Viewer.Domain.ValueObjects;
using DbfDataReader;

namespace CCG51.DBF.Viewer.Infrastructure.LocalFiles;

public sealed class DBFReader : IDBFReader
{
    public Task<DBFContent> ReadAsync(DBFFilePath dbfFilePath)
    {
        var tcs = new TaskCompletionSource<DBFContent>();
        var items = new List<string?[]>();
        Task.Run(() =>
        {
            var provider = CodePagesEncodingProvider.Instance;
            using var dbfTable = new DbfTable(dbfFilePath.Value, provider.GetEncoding("shift_jis"));
            var headers = dbfTable.Columns.Select(a => a.ColumnName).ToArray();
            var dbfRecord = new DbfRecord(dbfTable);
            while (dbfTable.Read(dbfRecord))
            {
                if (dbfRecord.IsDeleted)
                {
                    continue;
                }
                items.Add(dbfRecord.Values.Select(a => a.ToString()).ToArray());
            }
            var result = new DBFContent(headers, items);
            tcs.SetResult(result);

        });
        return tcs.Task;
    }
}

using System.Data;
using CCG51.DBF.Viewer.Domain.ValueObjects;

namespace CCG51.DBF.Viewer.Domain.Entities;

public sealed class TabItem
{
    public TabItem(DBFFilePath file, DataTable dataTable, IsLimit isLimit)
    {
        File = file;
        DataTable = dataTable;
        IsLimit = isLimit;
    }
    public DBFFilePath File { get; }
    public DataTable DataTable { get; }
    public IsLimit IsLimit { get; }
}

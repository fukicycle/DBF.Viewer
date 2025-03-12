namespace CCG51.DBF.Viewer.Domain.Entities;

public sealed class DBFContent
{
    public DBFContent(string[] headers,IEnumerable<string?[]> values)
    {
        Headers = headers;
        Values = values;
    }
    public string[] Headers { get; }
    public IEnumerable<string?[]> Values { get; }
}

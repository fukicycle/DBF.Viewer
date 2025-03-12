namespace CCG51.DBF.Viewer.Domain.ValueObjects;

public sealed class DBFFilePath : ValueObject<DBFFilePath>
{
    public DBFFilePath(string value)
    {
        Value = value;
        ShortName = new FileInfo(value).Name;
    }
    public string Value { get; }
    public string ShortName { get; }
    protected override bool EqualsCore(DBFFilePath other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }
}

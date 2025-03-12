namespace CCG51.DBF.Viewer.Domain.ValueObjects;

public sealed class IsLimit : ValueObject<IsLimit>
{
    public IsLimit(bool value)
    {
        Value = value;
        if (value)
        {
            DisplayValue = "このデータは大きすぎるため一部のデータのみを表示しています。";
        }
        else
        {
            DisplayValue = "";
        }
    }
    public bool Value { get; }
    public string DisplayValue { get; }
    protected override bool EqualsCore(IsLimit other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }
}

namespace KotorsGate.Domain.Constants;

public sealed class Alignment
{
    public static readonly Alignment Light = new Alignment("Light Side");
    public static readonly Alignment Dark = new Alignment("Dark Side");
    public static readonly Alignment Universal = new Alignment("Universal");
    

    private Alignment(string value)
    {
        this.Value = value;
    }

    public string Value { get; private set; }
}

namespace NbtSharp.Values;

internal readonly struct NbtDoubleVal : INbtValue
{
    public readonly double Value;
    
    public NbtDoubleVal(BinaryReader data)
    {
        Value = data.ReadDoubleBe();
    }
    
    public NbtDoubleVal(double v)
    {
        Value = v;
    }
    
    public string ToSnbt()
    {
        return $"{Value}d";
    }
}
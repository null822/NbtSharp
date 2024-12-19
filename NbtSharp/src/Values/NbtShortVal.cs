namespace NbtSharp.Values;

internal readonly struct NbtShortVal : INbtValue
{
    public readonly short Value;
    
    public NbtShortVal(BinaryReader data)
    {
        Value = data.ReadInt16Be();
    }
    
    public NbtShortVal(short v)
    {
        Value = v;
    }
    
    public string ToSnbt()
    {
        return $"{Value}s";
    }
}
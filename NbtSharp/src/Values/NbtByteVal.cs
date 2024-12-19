namespace NbtSharp.Values;

internal readonly struct NbtByteVal : INbtValue
{
    public readonly byte Value;
    
    public NbtByteVal(BinaryReader data)
    {
        Value = data.ReadByte();
    }
    
    public NbtByteVal(byte v)
    {
        Value = v;
    }
    
    public string ToSnbt()
    {
        return $"{Value}b";
    }
}
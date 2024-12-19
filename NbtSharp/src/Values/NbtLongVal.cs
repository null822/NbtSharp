namespace NbtSharp.Values;

internal readonly struct NbtLongVal : INbtValue
{
    public readonly long Value;
    
    public NbtLongVal(BinaryReader data)
    {
        Value = data.ReadInt64Be();
    }
    
    public NbtLongVal(long v)
    {
        Value = v;
    }
    
    public string ToSnbt()
    {
        return $"{Value}L";
    }
}
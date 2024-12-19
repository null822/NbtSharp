namespace NbtSharp.Values;

internal readonly struct NbtIntVal : INbtValue
{
    public readonly int Value;
    
    public NbtIntVal(BinaryReader data)
    {
        Value = data.ReadInt32Be();
    }
    
    public NbtIntVal(int v)
    {
        Value = v;
    }
    
    public string ToSnbt()
    {
        return $"{Value}";
    }
}
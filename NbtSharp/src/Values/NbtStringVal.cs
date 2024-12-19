namespace NbtSharp.Values;

internal readonly struct NbtStringVal : INbtValue
{
    public readonly string Value;
    
    public NbtStringVal(BinaryReader data)
    {
        Value = data.ReadStringBeShort();
    }
    
    public NbtStringVal(string v)
    {
        Value = v;
    }
    
    public string ToSnbt()
    {
        return $"\"{Value}\"";
    }
}
namespace NbtSharp.Values;

internal readonly struct NbtFloatVal : INbtValue
{
    public readonly float Value;
    
    public NbtFloatVal(BinaryReader data)
    {
        Value = data.ReadSingleBe();
    }
    
    public NbtFloatVal(float v)
    {
        Value = v;
    }
    
    public string ToSnbt()
    {
        return $"{Value}f";
    }
}
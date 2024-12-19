using NbtSharp.Values;

namespace NbtSharp.Types;

public class NbtFloat : INbtTag
{
    public string Name { get; set; }
    INbtValue INbtTag.ValueInternal => _value;
    public float Value => _value.Value;
    
    private readonly NbtFloatVal _value;
    
    public NbtFloat(string name, float value)
    {
        Name = name;
        _value = new NbtFloatVal(value);
    }
    
    internal NbtFloat(string name, NbtFloatVal value)
    {
        Name = name;
        _value = value;
    }
    
    internal NbtFloat(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _value = new NbtFloatVal(data);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_value.ToSnbt()}";
    }
}
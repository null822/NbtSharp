using NbtSharp.Values;

namespace NbtSharp.Types;

public class NbtShort : INbtTag
{
    public string Name { get; set; }
    INbtValue INbtTag.ValueInternal => _value;
    public short Value => _value.Value;
    
    private readonly NbtShortVal _value;
    
    public NbtShort(string name, short value)
    {
        Name = name;
        _value = new NbtShortVal(value);
    }
    
    internal NbtShort(string name, NbtShortVal value)
    {
        Name = name;
        _value = value;
    }
    
    internal NbtShort(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _value = new NbtShortVal(data);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_value.ToSnbt()}";
    }
}
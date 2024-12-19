using NbtSharp.Values;

namespace NbtSharp.Types;

public class NbtInt : INbtTag
{
    public string Name { get; set; }
    INbtValue INbtTag.ValueInternal => _value;
    public int Value => _value.Value;
    
    private readonly NbtIntVal _value;
    
    public NbtInt(string name, int value)
    {
        Name = name;
        _value = new NbtIntVal(value);
    }
    
    internal NbtInt(string name, NbtIntVal value)
    {
        Name = name;
        _value = value;
    }
    
    internal NbtInt(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _value = new NbtIntVal(data);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_value.ToSnbt()}";
    }
}
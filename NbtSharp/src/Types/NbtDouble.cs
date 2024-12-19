using NbtSharp.Values;

namespace NbtSharp.Types;

public class NbtDouble : INbtTag
{
    public string Name { get; set; }
    INbtValue INbtTag.ValueInternal => _value;
    public double Value => _value.Value;
    
    private readonly NbtDoubleVal _value;
    
    public NbtDouble(string name, double value)
    {
        Name = name;
        _value = new NbtDoubleVal(value);
    }
    
    internal NbtDouble(string name, NbtDoubleVal value)
    {
        Name = name;
        _value = value;
    }
    
    internal NbtDouble(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _value = new NbtDoubleVal(data);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_value.ToSnbt()}";
    }
}
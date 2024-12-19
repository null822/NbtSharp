using NbtSharp.Values;

namespace NbtSharp.Types;

public class NbtLong : INbtTag
{
    public string Name { get; set; }
    INbtValue INbtTag.ValueInternal => _value;
    public long Value => _value.Value;
    
    private readonly NbtLongVal _value;
    
    public NbtLong(string name, long value)
    {
        Name = name;
        _value = new NbtLongVal(value);
    }
    
    internal NbtLong(string name, NbtLongVal value)
    {
        Name = name;
        _value = value;
    }
    
    internal NbtLong(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _value = new NbtLongVal(data);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_value.ToSnbt()}";
    }
}
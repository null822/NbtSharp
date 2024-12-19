using NbtSharp.Values;

namespace NbtSharp.Types;

public class NbtByte : INbtTag
{
    public string Name { get; set; }
    INbtValue INbtTag.ValueInternal => _value;
    public byte Value => _value.Value;
    
    private readonly NbtByteVal _value;
    
    public NbtByte(string name, byte value)
    {
        Name = name;
        _value = new NbtByteVal(value);
    }
    
    internal NbtByte(string name, NbtByteVal value)
    {
        Name = name;
        _value = value;
    }
    
    internal NbtByte(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _value = new NbtByteVal(data);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_value.ToSnbt()}";
    }
}
using NbtSharp.Values;

namespace NbtSharp.Types;

public class NbtString : INbtTag
{
    public string Name { get; set; }
    INbtValue INbtTag.ValueInternal => _value;
    public string Value => _value.Value;
    
    private readonly NbtStringVal _value;
    
    public NbtString(string name, string value)
    {
        Name = name;
        _value = new NbtStringVal(value);
    }
    
    internal NbtString(string name, NbtStringVal value)
    {
        Name = name;
        _value = value;
    }
    
    internal NbtString(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _value = new NbtStringVal(data);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_value.ToSnbt()}";
    }
}
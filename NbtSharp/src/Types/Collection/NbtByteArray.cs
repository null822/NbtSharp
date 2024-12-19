using NbtSharp.Values;
using NbtSharp.Values.Collection;

namespace NbtSharp.Types.Collection;

public class NbtByteArray : INbtList<byte>, INbtTag
{
    public string Name { get; set; }
    public int Length => _values.Count;
    INbtValue INbtTag.ValueInternal => _values;
    
    private readonly NbtListVal<NbtByteVal> _values;
    
    public NbtByteArray(string name)
    {
        Name = name;
        _values = new NbtListVal<NbtByteVal>();
    }
    
    internal NbtByteArray(string name, NbtListVal<NbtByteVal> values)
    {
        Name = name;
        _values = values;
    }
    
    internal NbtByteArray(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _values = new NbtListVal<NbtByteVal>(data, NbtType.Byte);
    }
    
    public byte this[int i]
    {
        get => Get(i);
        set => Set(i, value);
    }
    
    public void Add(byte tag)
    {
        _values.Add(new NbtByteVal(tag));
    }
    
    public byte Get(int i)
    {
        if (i > _values.Count || i < 0)
            throw new IndexOutOfBoundsException(i, Length);
        
        return _values[i].Value;
    }

    public void Set(int i, byte value)
    {
        if (i > _values.Count || i < 0)
            throw new IndexOutOfBoundsException(i, Length);

        _values[i] = new NbtByteVal(value);
    }

    public IEnumerator<byte> GetEnumerator()
    {
        return _values.GetEnumerator(value => value.Value);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_values.ToSnbt()}";
    }
}


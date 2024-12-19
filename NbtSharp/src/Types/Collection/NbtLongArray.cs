using NbtSharp.Values;
using NbtSharp.Values.Collection;

namespace NbtSharp.Types.Collection;

public class NbtLongArray : INbtList<long>, INbtTag
{
    public string Name { get; set; }
    public int Length => _values.Count;
    INbtValue INbtTag.ValueInternal => _values;
    
    private readonly NbtListVal<NbtLongVal> _values;
    
    public NbtLongArray(string name)
    {
        Name = name;
        _values = new NbtListVal<NbtLongVal>();
    }
    
    internal NbtLongArray(string name, NbtListVal<NbtLongVal> values)
    {
        Name = name;
        _values = values;
    }
    
    internal NbtLongArray(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _values = new NbtListVal<NbtLongVal>(data, NbtType.Long);
    }
    
    public long this[int i]
    {
        get => Get(i);
        set => Set(i, value);
    }
    
    public void Add(long tag)
    {
        _values.Add(new NbtLongVal(tag));
    }
    
    public long Get(int i)
    {
        if (i > _values.Count || i < 0)
            throw new IndexOutOfBoundsException(i, Length);
        
        return _values[i].Value;
    }

    public void Set(int i, long value)
    {
        if (i > _values.Count || i < 0)
            throw new IndexOutOfBoundsException(i, Length);

        _values[i] = new NbtLongVal(value);
    }

    public IEnumerator<long> GetEnumerator()
    {
        return _values.GetEnumerator(value => value.Value);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_values.ToSnbt()}";
    }
}
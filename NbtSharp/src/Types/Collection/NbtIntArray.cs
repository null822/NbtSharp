using NbtSharp.Values;
using NbtSharp.Values.Collection;

namespace NbtSharp.Types.Collection;

public class NbtIntArray : INbtList<int>, INbtTag
{
    public string Name { get; set; }
    public int Length => _values.Count;
    INbtValue INbtTag.ValueInternal => _values;
    
    private readonly NbtListVal<NbtIntVal> _values;
    
    public NbtIntArray(string name)
    {
        Name = name;
        _values = new NbtListVal<NbtIntVal>();
    }
    
    internal NbtIntArray(string name, NbtListVal<NbtIntVal> values)
    {
        Name = name;
        _values = values;
    }
    
    internal NbtIntArray(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _values = new NbtListVal<NbtIntVal>(data, NbtType.Int);
    }
    
    public int this[int i]
    {
        get => Get(i);
        set => Set(i, value);
    }
    
    public void Add(int tag)
    {
        _values.Add(new NbtIntVal(tag));
    }
    
    public int Get(int i)
    {
        if (i > _values.Count || i < 0)
            throw new IndexOutOfBoundsException(i, Length);
        
        return _values[i].Value;
    }

    public void Set(int i, int value)
    {
        if (i > _values.Count || i < 0)
            throw new IndexOutOfBoundsException(i, Length);

        _values[i] = new NbtIntVal(value);
    }

    public IEnumerator<int> GetEnumerator()
    {
        return _values.GetEnumerator(value => value.Value);
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_values.ToSnbt()}";
    }
}
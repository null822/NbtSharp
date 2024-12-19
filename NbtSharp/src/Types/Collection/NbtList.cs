using System.Collections;
using NbtSharp.Values.Collection;

namespace NbtSharp.Types.Collection;

public class NbtList : NbtList<INbtTag>
{
    public NbtList(string name) : base(name) { }
    
    internal NbtList(string name, NbtListVal<INbtValue> values) : base(name, values) { }
    
    internal NbtList(BinaryReader data) : base(data) { }
}

public class NbtList<T> : INbtList<T>, INbtTag where T : INbtTag
{
    public string Name { get; set; }
    public int Length => _values.Count;
    INbtValue INbtTag.ValueInternal => _values;
    
    private readonly NbtListVal<INbtValue> _values;
    
    public NbtList(string name)
    {
        Name = name;
        _values = new NbtListVal<INbtValue>();
    }
    
    internal NbtList(string name, NbtListVal<INbtValue> values)
    {
        Name = name;
        _values = values;
    }
    
    internal NbtList(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _values = new NbtListVal<INbtValue>(data);
    }
    
    public T this[int i]
    {
        get => Get(i);
        set => Set(i, value);
    }
    
    public NbtList<T2> AsList<T2>() where T2 : INbtTag
    {
        return new NbtList<T2>(Name, _values);
    }
    
    public void Add(T tag)
    {
        _values.Add(tag.ValueInternal);
    }
    
    public T Get(int i)
    {
        if (i > _values.Count || i < 0)
            throw new IndexOutOfBoundsException(i, Length);
        
        return (T)_values[i].ToTag($"[{i}]");
    }
    
    public void Set(int i, T value)
    {
        if (i > _values.Count || i < 0)
            throw new IndexOutOfBoundsException(i, Length);

        _values[i] = value.ValueInternal;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return (IEnumerator<T>)_values.GetEnumerator(v => v.ToTag(""));
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public string ToSnbt()
    {
        return $"{Nbt.MakeSnbtSafe(Name)}: {_values.ToSnbt()}";
    }
}

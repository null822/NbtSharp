using System.Collections;
using System.Diagnostics.CodeAnalysis;
using NbtSharp.Values.Collection;

namespace NbtSharp.Types.Collection;

public class NbtCompound : INbtTag, IEnumerable<INbtTag>
{
    public string Name { get; set; }
    public int Length => _values.Count;
    INbtValue INbtTag.ValueInternal => _values;
    
    private readonly NbtCompoundVal _values;
    
    public NbtCompound(string name)
    {
        Name = name;
        _values = [];
    }
    
    internal NbtCompound(string name, NbtCompoundVal values)
    {
        Name = name;
        _values = values;
    }
    
    internal NbtCompound(BinaryReader data)
    {
        Name = data.ReadStringBeShort();
        _values = new NbtCompoundVal(data);
    }
    
    public T Get<T>(string name) where T : class, INbtTag
    {
        if (_values.Find(tag => tag.Name == name) is not T item)
            throw new MissingNbtTagException(name);
        
        return item;
    }
    
    public NbtList<T> GetList<T>(string name) where T : class, INbtTag
    {
        if (_values.Find(tag => tag.Name == name) is not NbtList list)
            throw new MissingNbtTagException(name);
        
        return list.AsList<T>();
    }
    
    public bool TryGet<T>(string name, [MaybeNullWhen(false)] out T tag) where T : class, INbtTag
    {
        if (_values.Find(tag => tag.Name == name) is T item)
        {
            tag = item;
            return true;
        }
        
        tag = default;
        return false;
    }
    
    public bool TryGetList<T>(string name, [MaybeNullWhen(false)] out NbtList<T> tag) where T : class, INbtTag
    {
        if (_values.Find(tag => tag.Name == name) is NbtList<INbtTag> item)
        {
            tag = item.AsList<T>();
            return true;
        }
        
        tag = default;
        return false;
    }
    
    public void Add<T>(T tag) where T : INbtTag
    {
        _values.Add(tag);
    }
    
    public void Set<T>(string name, T value) where T : INbtTag
    {
        var index = _values.FindIndex(tag => tag.Name == name);
        
        if (index == -1) throw new MissingNbtTagException(name);
        
        _values[index] = value;
    }
    
    public bool TrySet<T>(string name, T value) where T : INbtTag
    {
        var index = _values.FindIndex(tag => tag.Name == name);
        
        if (index == -1) return false;
        
        _values[index] = value;

        return true;
    }
    
    public IEnumerator<INbtTag> GetEnumerator()
    {
        return _values.GetEnumerator();
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

public class MissingNbtTagException(string tagName) : Exception($"NBT Tag {tagName} was not found, or was not of the correct type");
public class UnexpectedNbtTagTypeException(INbtTag tag, Type expected) : Exception($"NBT Tag of type \"{tag.GetType()}\" was not of the expected type: \"{expected}\"");

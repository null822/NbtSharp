using System.Collections;
using System.Text;

namespace NbtSharp.Values.Collection;

internal class NbtCompoundVal : INbtValue, IEnumerable<INbtTag>
{
    private readonly List<INbtTag> _values = [];
    public int Count => _values.Count;
    
    public NbtCompoundVal() { }
    
    public NbtCompoundVal(BinaryReader data)
    {
        // serialize all the children
        while (true)
        {
            var b = data.ReadByte();
            var tagType = (NbtType)b;
            
            // if all the children have been serialized, exit
            if (tagType is NbtType.End)
                break;
            
            var tag = Nbt.ReadTag(tagType, data);
            
            if (tag is null)
                throw new Exception($"Invalid Tag Type: {tagType}");
            
            Add(tag);
        }
    }
    
    public INbtTag this[int i]
    {
        get => _values[i];
        set => _values[i] = value;
    }
    
    public void Add(INbtTag value)
    {
        _values.Add(value);
    }

    public int IndexOf(INbtTag item)
    {
        return _values.IndexOf(item);
    }
    
    public INbtTag? Find(Predicate<INbtTag> match)
    {
        return _values.Find(match);
    }
    
    public int FindIndex(Predicate<INbtTag> match)
    {
        return _values.FindIndex(match);
    }
    
    public IEnumerator<INbtTag> GetEnumerator()
    {
        return _values.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _values.GetEnumerator();
    }
    
    public string ToSnbt()
    {
        var s = new StringBuilder();
        s.Append('{');
        foreach (var e in _values)
        {
            s.Append($"{e.ToSnbt()}, ");
        }
        
        if (s.Length >= 2) s.Remove(s.Length - 2, 2);
        s.Append('}');

        return s.ToString();
    }
}
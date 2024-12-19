using System.Collections;
using System.Text;

namespace NbtSharp.Values.Collection;

internal class NbtCollectionVal<T> : INbtValue, IEnumerable<T> where T : INbtValue
{
    protected readonly List<T> Value;
    public int Count => Value.Count;
    
    protected NbtCollectionVal()
    {
        Value = [];
    }
    
    protected NbtCollectionVal(List<T> v)
    {
        Value = v;
    }
    
    public T this[int i]
    {
        get => Value[i];
        set => Value[i] = value;
    }
    
    public void Add(T value)
    {
        Value.Add(value);
    }

    public int IndexOf(T item)
    {
        return Value.IndexOf(item);
    }
    
    public T? Find(Predicate<T> match)
    {
        return Value.Find(match);
    }
    
    public int FindIndex(Predicate<T> match)
    {
        return Value.FindIndex(match);
    }

    public virtual IEnumerator<T> GetEnumerator()
    {
        return Value.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return Value.GetEnumerator();
    }
    
    public string ToSnbt()
    {
        var s = new StringBuilder();
        s.Append('{');
        foreach (var e in Value)
        {
            s.Append($"{e.ToSnbt()}, ");
        }
        
        if (s.Length >= 2) s.Remove(s.Length - 2, 2);
        s.Append('}');

        return s.ToString();
    }
    
    
    public static explicit operator NbtCollectionVal<T>(List<T> value)
    {
        return new NbtCollectionVal<T>(value);
    }
    
    public static implicit operator List<T>(NbtCollectionVal<T> value)
    {
        return value.Value;
    }
    
}
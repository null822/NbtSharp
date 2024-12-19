using System.Collections;

namespace NbtSharp;

internal interface INbtList<T> : IEnumerable<T>
{
    public int Length { get; }
    
    public T this[int i] { get; set; }
    public void Add(T tag);
    public T Get(int i);
    public void Set(int i, T value);
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

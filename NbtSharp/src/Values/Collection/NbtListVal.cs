using System.Collections;
using System.Text;
using NbtSharp.Types;

namespace NbtSharp.Values.Collection;

internal class NbtListVal<T> : INbtValue where T : INbtValue
{
    protected readonly List<T> Value = [];
    public int Count => Value.Count;
    
    public NbtListVal() { }
    
    public NbtListVal(BinaryReader data, NbtType type = NbtType.Invalid)
    {
        if (type == NbtType.Invalid)
            type = (NbtType)data.ReadByte();
        
        var length = data.ReadInt32Be();
        
        for (var i = 0; i < length; i++)
        {
            INbtValue value = type switch
            {
                NbtType.Byte => new NbtByteVal(data.ReadByte()),
                NbtType.Short => new NbtShortVal(data.ReadInt16Be()),
                NbtType.Int => new NbtIntVal(data.ReadInt32Be()),
                NbtType.Long => new NbtLongVal(data.ReadInt64Be()),
                NbtType.Float => new NbtFloatVal(data.ReadSingleBe()),
                NbtType.Double => new NbtDoubleVal(data.ReadDoubleBe()),
                NbtType.String => new NbtStringVal(data.ReadStringBeShort()),
            
                NbtType.Compound => new NbtCompoundVal(data),
                
                NbtType.List => new NbtListVal<INbtValue>(data),
                
                NbtType.ByteArray => new NbtListVal<NbtByteVal>(data, NbtType.Byte),
                NbtType.IntArray => new NbtListVal<NbtIntVal>(data, NbtType.Int),
                NbtType.LongArray => new NbtListVal<NbtLongVal>(data, NbtType.Long),
                
                _ => throw new Exception($"Invalid {nameof(NbtType)}: {type}")
            };
            
            Add((T)value);
        }
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
    
    public NbtListEnumerator<TValue, T> GetEnumerator<TValue>(NbtValueConverter<TValue, T> converter)
    {
        return new NbtListEnumerator<TValue, T>(Value, converter);
    }
    
    public string ToSnbt()
    {
        var typePrefix = typeof(T).Name switch
        {
            "NbtByteVal" => "B; ",
            "NbtIntVal" => "I; ",
            "NbtLongVal" => "L; ",
            _ => ""
        };
        Console.WriteLine(typeof(T).Name);
        
        var s = new StringBuilder($"[{typePrefix}");
        
        foreach (var e in Value)
        {
            s.Append($"{e.ToSnbt()}, ");
        }
        
        if (s.Length >= 2) s.Remove(s.Length - 2, 2);
        s.Append(']');

        return s.ToString();
    }
}

internal delegate T NbtValueConverter<out T, in TBase>(TBase value);

public class NbtListEnumerator<T, TBase> : IEnumerator<T> where TBase : INbtValue
{
    private readonly List<TBase> _values;
    private readonly NbtValueConverter<T, TBase> _converter;
    private readonly bool _isEmpty;

    private int _currentIndex = -1;
    
    public T Current { get; private set; }
    object? IEnumerator.Current => Current;
    
    internal NbtListEnumerator(List<TBase> values, NbtValueConverter<T, TBase> converter)
    {
        _values = values;
        _converter = converter;
        _isEmpty = _values.Count == 0;
    }
    
    public bool MoveNext()
    {
        if (_currentIndex >= _values.Count - 1)
            return false;
        
        _currentIndex++;
        if (!_isEmpty)
            Current = _converter.Invoke(_values[_currentIndex]);
        
        return true;
    }

    public void Reset()
    {
        _currentIndex = 0;
        if (!_isEmpty)
            Current = _converter.Invoke(_values[_currentIndex]);
    }
    
    public void Dispose()
    {
        
    }
}
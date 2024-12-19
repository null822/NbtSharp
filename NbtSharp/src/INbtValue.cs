using NbtSharp.Types;
using NbtSharp.Types.Collection;
using NbtSharp.Values;
using NbtSharp.Values.Collection;

namespace NbtSharp;

public interface INbtValue
{
    internal string ToSnbt();
    
    internal INbtTag ToTag(string name)
    {
        return this switch
        {
            NbtByteVal v => new NbtByte(name, v),
            NbtShortVal v => new NbtShort(name, v),
            NbtIntVal v => new NbtInt(name, v),
            NbtLongVal v => new NbtLong(name, v),
            NbtStringVal v => new NbtString(name, v),
            NbtFloatVal v => new NbtFloat(name, v),
            NbtDoubleVal v => new NbtDouble(name, v),
            
            NbtListVal<INbtValue> v => new NbtList(name, v),
            NbtCompoundVal v => new NbtCompound(name, v),
            
            NbtListVal<NbtByteVal> v => new NbtByteArray(name, v),
            NbtListVal<NbtIntVal> v => new NbtIntArray(name, v),
            NbtListVal<NbtLongVal> v => new NbtLongArray(name, v),
            
            _ => throw new NotImplementedException()
        };
    }
}

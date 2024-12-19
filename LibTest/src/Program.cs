using NbtSharp;
using NbtSharp.Types;
using NbtSharp.Types.Collection;

namespace LibTest;

public static class Program
{
    public static void Main()
    {
        var nbt = Nbt.Read("test.nbt");
        
        if (nbt.TryGet<NbtInt>("int", out var v))
        {
            Console.WriteLine(v.ToSnbt());
        }
        
        Console.WriteLine(nbt.Get<NbtInt>("int").ToSnbt());
        
        Console.WriteLine(nbt.GetList<NbtLong>("list<long>").ToSnbt());
        
        Console.WriteLine(nbt.GetList<NbtList>("list<list>")[0].AsList<NbtCompound>()[0].Get<NbtShort>("short").ToSnbt());
        Console.WriteLine(nbt.GetList<NbtList<NbtLong>>("list<list>").ToSnbt());
        
        Console.WriteLine(nbt.ToSnbt());
    }
}

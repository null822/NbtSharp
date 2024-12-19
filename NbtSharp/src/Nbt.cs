using System.IO.Compression;
using System.Text;
using NbtSharp.Types;
using NbtSharp.Types.Collection;

namespace NbtSharp;

public static class Nbt
{
    public static NbtCompound Read(string filePath)
    {
        var stream = File.OpenRead(filePath);
        var nbt = Read(stream);
        stream.Dispose();
        
        return nbt;
    }
    
    public static NbtCompound Read(Stream stream)
    {
        var position = stream.Position;
        Stream rawStream;
        var dispose = false;
        try
        {
            var gZipStream = new GZipStream(stream, CompressionMode.Decompress, true);
            rawStream = new MemoryStream();
            // try to read stream (exception thrown if stream is not gzipped)
            gZipStream.CopyTo(rawStream);
            
            rawStream.Position = 0;
            dispose = true; // only dispose if the stream is the GZipStream
        }
        catch (Exception e)
        {
            if (e is InvalidDataException)
            {
                rawStream = stream;
                rawStream.Position = position;
            }
            else
                throw;
        }
        
        var data = new BinaryReader(rawStream, Encoding.UTF8, true);
        var type = (NbtType)data.ReadByte();
        var nbt = ReadTag(type, data) as NbtCompound 
                  ?? throw new InvalidNbtFileException("NBT was not enclosed in a Compound tag");
        
        data.Dispose();
        if (dispose) rawStream.Dispose();
        
        return nbt;
    }
    
    internal static INbtTag ReadTag(NbtType tagType, BinaryReader data)
    {
        return tagType switch
        {
            NbtType.Byte => new NbtByte(data),
            NbtType.Short => new NbtShort(data),
            NbtType.Int => new NbtInt(data),
            NbtType.Long => new NbtLong(data),
            NbtType.Float => new NbtFloat(data),
            NbtType.Double => new NbtDouble(data),
            NbtType.String => new NbtString(data),
            
            NbtType.Compound => new NbtCompound(data),
            NbtType.List => new NbtList(data),
            
            NbtType.ByteArray => new NbtByteArray(data),
            NbtType.IntArray => new NbtIntArray(data),
            NbtType.LongArray => new NbtLongArray(data),
            
            _ => throw new InvalidNbtFileException($"Invalid {nameof(NbtType)}: {tagType}")
        };
    }

    internal static string MakeSnbtSafe(string name)
    {
        name = name.Replace(@"\", @"\\");
        name = name.Replace("\"", "\\\"");
        name = name.Replace("\'", "\\\'");
        
        if (name.Any(c => !IsAllowedChar(c)))
        {
            name = $"\"{name}\"";
        }
        
        
        
        return name;
    }

    private static bool IsAllowedChar(char c)
    {
        var v = (int)c;
        
        return v is '_' or '-' or '.' or '+'
            or >= 0x30 and <= 0x39 // 0-9
            or >= 0x41 and <= 0x5A // A-Z
            or >= 0x61 and <= 0x7A;// a-z
    }
}

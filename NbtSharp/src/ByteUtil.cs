using System.Text;

namespace NbtSharp;

internal static class ByteUtil
{
    #region Little Endian
    
    public static byte[] GetBytesLe(byte v)
    {
        return [v];
    }
    
    public static byte[] GetBytesLe(short v)
    {
        return [
            (byte)((v >> 8) & 0xFF),
            (byte)((v >> 0) & 0xFF)
        ];
    }
    
    public static byte[] GetBytesLe(ushort v)
    {
        return [
            (byte)((v >> 8) & 0xFF),
            (byte)((v >> 0) & 0xFF)
        ];
    }
    
    public static byte[] GetBytesLe(int v)
    {
        return [
            (byte)((v >> 24) & 0xFF),
            (byte)((v >> 16) & 0xFF),
            (byte)((v >>  8) & 0xFF),
            (byte)((v >>  0) & 0xFF)
        ];
    }
    
    public static byte[] GetBytesLe(uint v)
    {
        return [
            (byte)((v >> 24) & 0xFF),
            (byte)((v >> 16) & 0xFF),
            (byte)((v >>  8) & 0xFF),
            (byte)((v >>  0) & 0xFF)
        ];
    }
    
    public static byte[] GetBytesLe(long v)
    {
        return [
            (byte)((v >> 56) & 0xff),
            (byte)((v >> 48) & 0xff),
            (byte)((v >> 40) & 0xff),
            (byte)((v >> 32) & 0xff),
            (byte)((v >> 24) & 0xff),
            (byte)((v >> 16) & 0xff),
            (byte)((v >>  8) & 0xff),
            (byte)((v >>  0) & 0xff),
        ];
    }
    
    public static byte[] GetBytesLe(ulong v)
    {
        return [
            (byte)((v >> 56) & 0xff),
            (byte)((v >> 48) & 0xff),
            (byte)((v >> 40) & 0xff),
            (byte)((v >> 32) & 0xff),
            (byte)((v >> 24) & 0xff),
            (byte)((v >> 16) & 0xff),
            (byte)((v >>  8) & 0xff),
            (byte)((v >>  0) & 0xff),
        ];
    }
    
    public static short GetShortLe(Span<byte> d)
    {
        return (short)((d[0] << 8) |
                       (d[1] << 0));
    }
    
    public static ushort GetUShortLe(Span<byte> d)
    {
        return (ushort)((d[0] << 8) |
                        (d[1] << 0));
    }
    
    public static int GetIntLe(Span<byte> d)
    {
        return (d[0] << 24) |
               (d[1] << 16) |
               (d[2] <<  8) |
               (d[3] << 0);
    }
    
    public static uint GetUIntLe(Span<byte> d)
    {
        return (uint)(d[0] << 24) |
               (uint)(d[1] << 16) |
               (uint)(d[2] <<  8) |
               (uint)(d[3] <<  0);
    }
    
    public static long GetLongLe(Span<byte> d)
    {
        return ((long)d[0] << 56) |
               ((long)d[1] << 48) |
               ((long)d[2] << 40) |
               ((long)d[3] << 32) |
               ((long)d[4] << 24) |
               ((long)d[5] << 16) |
               ((long)d[6] <<  8) |
               ((long)d[7] <<  0);
    }
    
    public static ulong GetULongLe(Span<byte> d)
    {
        return ((ulong)d[0] << 56) |
               ((ulong)d[1] << 48) |
               ((ulong)d[2] << 40) |
               ((ulong)d[3] << 32) |
               ((ulong)d[4] << 24) |
               ((ulong)d[5] << 16) |
               ((ulong)d[6] <<  8) |
               ((ulong)d[7] <<  0);
    }
    
    public static float GetFloatLe(Span<byte> d)
    {
        return BitConverter.Int32BitsToSingle(GetIntLe(d));
    }
    
    public static double GetDoubleLe(Span<byte> d)
    {
        return BitConverter.Int64BitsToDouble(GetLongLe(d));
    }
    
    #endregion

    #region Big Endian
    
    public static byte[] GetBytesBe(byte v)
    {
        return [v];
    }
    
    public static byte[] GetBytesBe(short v)
    {
        return [
            (byte)((v >> 0) & 0xFF),
            (byte)((v >> 8) & 0xFF)
        ];
    }
    
    public static byte[] GetBytesBe(ushort v)
    {
        return [
            (byte)((v >> 0) & 0xFF),
            (byte)((v >> 8) & 0xFF)
        ];
    }
    
    public static byte[] GetBytesBe(int v)
    {
        return [
            (byte)((v >>  0) & 0xFF),
            (byte)((v >>  8) & 0xFF),
            (byte)((v >> 16) & 0xFF),
            (byte)((v >> 24) & 0xFF)
        ];
    }
    
    public static byte[] GetBytesBe(uint v)
    {
        return [
            (byte)((v >>  0) & 0xFF),
            (byte)((v >>  8) & 0xFF),
            (byte)((v >> 16) & 0xFF),
            (byte)((v >> 24) & 0xFF)
        ];
    }
    
    public static byte[] GetBytesBe(long v)
    {
        return [
            (byte)((v >>  0) & 0xff),
            (byte)((v >>  8) & 0xff),
            (byte)((v >> 18) & 0xff),
            (byte)((v >> 24) & 0xff),
            (byte)((v >> 32) & 0xff),
            (byte)((v >> 40) & 0xff),
            (byte)((v >> 48) & 0xff),
            (byte)((v >> 56) & 0xff),
        ];
    }
    
    public static byte[] GetBytesBe(ulong v)
    {
        return [
            (byte)((v >>  0) & 0xff),
            (byte)((v >>  8) & 0xff),
            (byte)((v >> 16) & 0xff),
            (byte)((v >> 24) & 0xff),
            (byte)((v >> 32) & 0xff),
            (byte)((v >> 40) & 0xff),
            (byte)((v >> 48) & 0xff),
            (byte)((v >> 56) & 0xff),
        ];
    }
    
    public static short GetShortBe(Span<byte> d)
    {
        return (short)((d[0] << 0) |
                       (d[1] << 8));
    }
    
    public static ushort GetUShortBe(Span<byte> d)
    {
        return (ushort)((d[0] << 0) |
                        (d[1] << 8));
    }
    
    public static int GetIntBe(Span<byte> d)
    {
        return (d[0] <<  0) |
               (d[1] <<  8) |
               (d[2] << 16) |
               (d[3] << 24);
    }
    
    public static uint GetUIntBe(Span<byte> d)
    {
        return (uint)(d[0] <<  0) |
               (uint)(d[1] <<  8) |
               (uint)(d[2] << 16) |
               (uint)(d[3] << 24);
    }
    
    public static long GetLongBe(Span<byte> d)
    {
        return ((long)d[0] <<  0) |
               ((long)d[1] <<  8) |
               ((long)d[2] << 16) |
               ((long)d[3] << 24) |
               ((long)d[4] << 32) |
               ((long)d[5] << 40) |
               ((long)d[6] << 48) |
               ((long)d[7] << 56);
    }
    
    public static ulong GetULongBe(Span<byte> d)
    {
        return ((ulong)d[0] <<  0) |
               ((ulong)d[1] <<  8) |
               ((ulong)d[2] << 16) |
               ((ulong)d[3] << 24) |
               ((ulong)d[4] << 32) |
               ((ulong)d[5] << 40) |
               ((ulong)d[6] << 48) |
               ((ulong)d[7] << 56);
    }
    
    public static float GetFloatBe(Span<byte> d)
    {
        return BitConverter.Int32BitsToSingle(GetIntBe(d));
    }
    
    public static double GetDoubleBe(Span<byte> d)
    {
        return BitConverter.Int64BitsToDouble(GetLongBe(d));
    }
    
    #endregion
    
    #region Big Endian BinaryReader
    
    public static short ReadInt16Be(this BinaryReader reader)
    {
        return GetShortBe(reader.ReadBytesRequired(sizeof(short)).ReverseRet());
    }
    
    public static ushort ReadUInt16Be(this BinaryReader reader)
    {
        return GetUShortBe(reader.ReadBytesRequired(sizeof(ushort)).ReverseRet());
    }
    
    public static int ReadInt32Be(this BinaryReader reader)
    {
        return GetIntBe(reader.ReadBytesRequired(sizeof(int)).ReverseRet());
    }
    
    public static uint ReadUInt32Be(this BinaryReader reader)
    {
        return GetUIntBe(reader.ReadBytesRequired(sizeof(uint)).ReverseRet());
    }
    
    public static long ReadInt64Be(this BinaryReader reader)
    {
        return GetLongBe(reader.ReadBytesRequired(sizeof(long)).ReverseRet());
    }
    
    public static ulong ReadUInt64Be(this BinaryReader reader)
    {
        return GetULongBe(reader.ReadBytesRequired(sizeof(ulong)).ReverseRet());
    }
    
    
    public static float ReadSingleBe(this BinaryReader reader)
    {
        return GetFloatBe(reader.ReadBytesRequired(sizeof(int)).ReverseRet());
    }
    
    public static double ReadDoubleBe(this BinaryReader reader)
    {
        return GetDoubleBe(reader.ReadBytesRequired(sizeof(long)).ReverseRet());
    }
    
    
    public static string ReadStringBeShort(this BinaryReader reader, Encoding? encoding = default)
    {
        encoding ??= Encoding.UTF8;
        
        var strLen = reader.ReadUInt16Be();
        return encoding.GetString(reader.ReadBytes(strLen));
    }
    
    /// <summary>
    /// Reads bytes from this <see cref="BinaryReader"/>, and throws an exception if not all bytes could be read.
    /// </summary>
    /// <param name="reader">this <see cref="BinaryReader"/></param>
    /// <param name="byteCount">the amount of bytes to read</param>
    /// <returns>the bytes that were read</returns>
    public static Span<byte> ReadBytesRequired(this BinaryReader reader, int byteCount)
    {
        var result = new Span<byte>(reader.ReadBytes(byteCount));
        
        if (result.Length != byteCount)
            throw new EndOfStreamException(
                $"{byteCount} bytes required from stream, but only {result.Length} returned");
        
        return result;
    }
    
    #endregion
    
    public static string GetString(Span<byte> d)
    {
        return Encoding.UTF8.GetString(d);
    }
    
    public static Span<byte> ReverseRet(this Span<byte> b)
    {
        b.Reverse();
        return b;
    }
    
}

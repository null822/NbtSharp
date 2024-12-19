﻿namespace NbtSharp;

public enum NbtType : byte
{
    End = 0,
    Byte = 1,
    Short = 2,
    Int = 3,
    Long = 4,
    Float = 5,
    Double = 6,
    String = 8,
    List = 9,
    Compound = 10,
    ByteArray = 7,
    IntArray = 11,
    LongArray = 12,
    
    Invalid = 0xFF
}
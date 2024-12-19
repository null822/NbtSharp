namespace NbtSharp;

public class IndexOutOfBoundsException(int i, int length) : Exception($"Index {i} out of bounds for length {length}");

public class InvalidNbtFileException(string msg = "") : Exception(msg);
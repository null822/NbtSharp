
namespace NbtSharp;


public interface INbtTag
{
    public string Name { get; set; }
    internal INbtValue ValueInternal { get; }

    public string ToSnbt();
}

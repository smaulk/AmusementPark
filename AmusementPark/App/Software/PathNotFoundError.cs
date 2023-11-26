using System.Runtime.Serialization;

namespace AmusementPark;

public class PathNotFoundError: Exception
{
    protected readonly string _path;
 
    protected PathNotFoundError(SerializationInfo info, StreamingContext context, string path) : base(info, context)
    {
        _path = path;
    }
 
    public PathNotFoundError(string? message, string path) : base(message)
    {
        _path = path;
    }
 
    public PathNotFoundError(string? message, Exception? innerException, string path) : base(message, innerException)
    {
        _path = path;
    }
 
 
    public string Path => _path;
}
namespace ServerSimulation;

/// <summary>
/// An exception that is thrown when a path for a server or endpoint is invalid.
/// </summary>
public class InvalidPathException : Exception
{
    public InvalidPathException() : base() { }
    public InvalidPathException(string message) : base(message) { }
    public InvalidPathException(string message, Exception? innerException) : base(message, innerException) { }
}
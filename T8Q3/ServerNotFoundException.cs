namespace ServerSimulation;

/// <summary>
/// An exception that is thrown when the server is not found.
/// </summary>
public class ServerNotFoundException : Exception
{
    public ServerNotFoundException() : base() { }
    public ServerNotFoundException(string message) : base(message) { }
    public ServerNotFoundException(string message, Exception? innerException) : base(message, innerException) { }
}
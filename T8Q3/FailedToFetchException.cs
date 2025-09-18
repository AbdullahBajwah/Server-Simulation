namespace ServerSimulation;

/// <summary>
/// An exception that is thrown when a request to a server fails.
/// </summary>
public class FailedRequestException : Exception
{
    public FailedRequestException() : base() { }
    public FailedRequestException(string message) : base(message) { }
    public FailedRequestException(string message, Exception? innerException) : base(message,innerException) { }
}
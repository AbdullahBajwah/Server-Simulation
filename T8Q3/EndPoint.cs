namespace ServerSimulation;

/// <summary>
/// An endpoint of a server that can be accessed by a client.
/// </summary>
class EndPoint
{
    private string path;

    /// <summary>
    /// The path of the endpoint, without the server identifier. Must start with /.
    /// </summary>
    /// <exception cref="InvalidPathException">Thrown when the path does not start with /.</exception>
    public string Path
    {
        get
        {
            return path;
        }
        set
        {
            if (!value.StartsWith("/"))
            {
                throw new InvalidPathException("Endpoint path must start with /");
            }

            path = value;
        }
    }
    
    /// <summary>
    /// The response of the endpoint
    /// </summary>
    public virtual string Response { get; protected set; }

    /// <summary>
    /// Creates a new endpoint with the given path and response.
    /// </summary>
    /// <param name="path">The path of the endpoint.</param>
    /// <param name="response">The response of the endpoint.</param>
    public EndPoint(string path, string response)
    {
        Path = path; 
        Response = response;
    }

    /// <summary>
    /// Creates a new endpoint with the given path and a default response of "Success."
    /// </summary>
    /// <param name="path">The path of the endpoint.</param>
    public EndPoint(string path) : this(path, "Success")
    {
    }
}

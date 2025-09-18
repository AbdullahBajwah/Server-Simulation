namespace ServerSimulation;

/// <summary>
/// Represents a server.
/// </summary>
class Server
{
    private List<EndPoint> endPoints;
    private string identifier;

    /// <summary>
    /// The identifier of the server.
    /// </summary>
    /// <exception cref="InvalidPathException">Thrown when the identifier is null or empty, or contains /.</exception>
    public string Identifier
    {
        get
        {
            return identifier;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidPathException("Identifier cannot be null or empty");
            }

            if (value.Contains('/'))
            {
                throw new InvalidPathException("Server identifier cannot contain /");
            }

            identifier = value;
        }
    }

    /// <summary>
    /// Gets the end points of the server.
    /// </summary>
    public EndPoint[] EndPoints
    {
        get
        {
            return endPoints.ToArray();
        }
    }

    /// <summary>
    /// Creates a new server with the given identifier. All servers contain a /list endpoint by default.
    /// </summary>
    /// <param name="identifier">The identifier of the server.</param>
    public Server(string identifier)
    {
        Identifier = identifier;
        endPoints = new List<EndPoint>()
        {
            new ListEndPoint(this)
        };
    }

    /// <summary>
    /// Adds a unique endpoint to the server.
    /// </summary>
    /// <param name="path">The path of the endpoint.</param>
    /// <param name="response">The response of the endpoint.</param>
    /// <exception cref="ArgumentException">Thrown when the path already exists in the server.</exception>
    public void AddEndPoint(string path, string response)
    {
        foreach (EndPoint endPoint in endPoints)
        {
            if (endPoint.Path.Equals(path))
            {
                throw new ArgumentException($"Path {path} already exists in server {Identifier}");
            }
        }
        endPoints.Add(new EndPoint(path, response));
    }

    /// <summary>
    /// Gets the response of the endpoint with the given path.
    /// </summary>
    /// <param name="path">The path of the endpoint.</param>
    /// <returns>The response of the endpoint.</returns>
    /// <exception cref="InvalidPathException">Thrown when the path does not exist in the server.</exception>
    public string GetResponse(string path)
    {
        foreach (EndPoint endPoint in endPoints)
        {
            if (endPoint.Path.Equals(path))
            {
                return endPoint.Response;
            }
        }

        throw new InvalidPathException($"Endpoint {path} not found in server {Identifier}");
        return "404";
    }
}


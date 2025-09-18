namespace ServerSimulation;

/// <summary>
/// Represents a client that can get responses from some registered servers.
/// </summary>
class Client
{ 
    /// <summary>
    /// Parses the given path and gets the server and server path.
    /// </summary>
    /// <param name="path">The path to parse.</param>
    /// <param name="serverHub">The server hub to search the for the server in.</param>
    /// <param name="server">Output parameter for the server found.</param>
    /// <param name="endPoint">Output parameter for the server path.</param>
    /// <exception cref="InvalidPathException">Throws a new exception if the path is invalid.</exception>
    private static void ProcessPath(string path, ServerHub serverHub, out Server? server, out string endPoint)
    {
        string[] pathParts = path.Split("/");
        
        if (pathParts.Length < 2)
        {
            throw new InvalidPathException(
                $"Invalid path {path}, must contain server identifier and endpoint path, separated by /");
        }

        string serverIdentifier = pathParts[0];
        server = serverHub.SearchServer(serverIdentifier);

        if (server == null)
        {
            throw new ServerNotFoundException($"Server {serverIdentifier} not registered");
        }

        endPoint = "/" + string.Join("/", pathParts[1..]);
    }

    /// <summary>
    /// Gets the response using the given path and server hub.
    /// </summary>
    /// <param name="path">The path to get the response from, in the format serverIdentifier/endpointPath.</param>
    /// <param name="serverHub">The server hub to get the response from.</param>
    /// <returns>The response of the server endpoint.</returns>
    /// <exception cref="FailedRequestException">Thrown when the response could not be fetched.</exception>
    public string Fetch(string path, ServerHub serverHub)
    {
        try
        {
            ProcessPath(path, serverHub, out Server? server, out string endPoint);
            return server.GetResponse(endPoint);
        }
        catch (Exception exception)
        {
            throw new FailedRequestException($"Could not fetch the given path {path}", exception);
        }
    }
}


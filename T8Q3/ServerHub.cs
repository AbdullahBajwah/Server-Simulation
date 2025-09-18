namespace ServerSimulation;

/// <summary>
/// A hub of registered servers.
/// </summary>
class ServerHub
{
    private List<Server> servers;

    /// <summary>
    /// Creates a new server hub.
    /// </summary>
    public ServerHub()
    {
        servers = new List<Server>();
    }

    /// <summary>
    /// Adds a server to the hub, if it does not exist.
    /// </summary>
    /// <param name="identifier">The identifier of the server.</param>
    /// <exception cref="ArgumentException">Thrown when the server already exists.</exception>
    private void AddServer(string identifier)
    {
        if (SearchServer(identifier) != null)
        {
            throw new ArgumentException($"Server {identifier} already exists");
        }
        servers.Add(new Server(identifier));
    }

    /// <summary>
    /// Adds an endpoint to the server with the given identifier, if it exists.
    /// </summary>
    /// <param name="identifier">The identifier of the server.</param>
    /// <param name="path">The path of the endpoint.</param>
    /// <param name="response">The response of the endpoint.</param>
    /// <exception cref="ServerNotFoundException">Thrown when the server does not exist.</exception>
    private void AddEndPoint(string identifier, string path, string response)
    {
        Server? server = SearchServer(identifier);
        if (server == null)
        {
            throw new ServerNotFoundException($"Cannot add endpoint to non-existent server {identifier}");
        }
        server.AddEndPoint(path, response);
    }

    /// <summary>
    /// Adds a server to the hub using console input.
    /// </summary>
    public void AddServerFromConsole()
    {
        Console.WriteLine("Enter the server identifier (must not contain /):");
        string identifier = Console.ReadLine()!;
        AddServer(identifier);
    }

    /// <summary>
    /// Adds an endpoint to the server with the given identifier using console input.
    /// </summary>
    public void AddEndPointFromConsole()
    {
        Console.WriteLine("Enter the server identifier:");
        string identifier = Console.ReadLine()!;
        Console.WriteLine("Enter the endpoint path (must start with /):");
        string path = Console.ReadLine()!;
        Console.WriteLine("Enter the endpoint response:");
        string response = Console.ReadLine()!;
        AddEndPoint(identifier, path, response);
    }

    /// <summary>
    /// Searches for a server with the given identifier.
    /// </summary>
    /// <param name="identifier">The identifier of the server.</param>
    /// <returns>The server, if it exists. Null otherwise.</returns>
    public Server? SearchServer(string identifier)
    {
        foreach (Server server in servers)
        {
            if (server.Identifier.Equals(identifier))
            {
                return server;
            }
        }

        return null;
    }

    /// <summary>
    /// Lists all servers registered in the hub.
    /// </summary>
    public void ListServers()
    {
        Console.WriteLine("Available servers:");
        foreach (Server server in servers)
        {
            Console.WriteLine(server.Identifier);
        }
    }

    /// <summary>
    /// Gets the server data from console input.
    /// </summary>
    /// <param name="client">The client used to connect to the server.</param>
    public void GetServerDataFromConsole(Client client)
    {
        Console.WriteLine("Enter the path (serverIdentifier/endpointPath):");
        string path = Console.ReadLine()!;
        Console.WriteLine("The server responded:");
        Console.WriteLine(client.Fetch(path, this));
    }
}




using System.Xml.Linq;

namespace ServerSimulation;

class Program
{
    enum MenuOption
    {
        Default,
        ListServers,
        AddServer,
        AddEndPoint,
        GetDataFromServer,
        Exit
    }
    static void Main(string[] args)
    {
        Console.WriteLine("===========================");
        ServerHub servers = new ServerHub();
        Client client = new Client();

        MenuOption option = MenuOption.Default;
        while (option != MenuOption.Exit)
        {
            option = ReadOption();

            try
            {
                OnOptionSelected(option, servers, client);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error of type {exception.GetType()} occurred: {exception.Message}");
                if (exception.InnerException != null)
                {
                    Console.WriteLine($"An inner exception of type {exception.InnerException.GetType()} occurred: {exception.InnerException.Message}");
                }
            }
        }
        Console.WriteLine("===========================");
    }

    /// <summary>
    /// Reads the option from the console.
    /// </summary>
    /// <returns>The option.</returns>
    static MenuOption ReadOption()
    {
        Console.WriteLine("---------------------------");
        foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
        {
            if (option == MenuOption.Default)
            {
                continue;
            }
            Console.WriteLine($"{(int)option}. {option}");
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Enter your option:");
        string optionStr = Console.ReadLine()!;
        if (int.TryParse(optionStr, out int optionInt))
        {
            return (MenuOption)optionInt;
        }

        return MenuOption.Default;
    }

    /// <summary>
    /// Executes the option selected.
    /// </summary>
    /// <param name="option">The option selected.</param>
    /// <param name="serverHub">The hub of registered servers.</param>
    /// <param name="client">The client.</param>
    /// <returns>The option selected.</returns>
    static void OnOptionSelected(MenuOption option, ServerHub serverHub, Client client)
    {
        switch (option)
        {
            case MenuOption.ListServers:
                serverHub.ListServers();
                break;
            case MenuOption.AddServer:
                serverHub.AddServerFromConsole();
                break;
            case MenuOption.AddEndPoint:
                serverHub.AddEndPointFromConsole();
                break;
            case MenuOption.GetDataFromServer:
                serverHub.GetServerDataFromConsole(client);
                break;
            case MenuOption.Exit:
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
}
public class GameManager
{
    private GameLoop gameLoop = new GameLoop();

    public void Run()
    {
        ShowMenu();
    }

    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Game!");
        Console.WriteLine("1. Start Game");
        Console.WriteLine("2. About");
        Console.WriteLine("3. Exit");
        Console.WriteLine("\nChoose an option...");

        var key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.D1:
                StartGame();
                break;
            case ConsoleKey.D2:
                ShowAbout();
                break;
            case ConsoleKey.D3:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Press any key to try again...");
                Console.ReadKey();
                ShowMenu();
                break;
        }
    }

    private void StartGame()
    {
        Console.Clear();
        Console.WriteLine("Starting game...");
        gameLoop.Start();
    }

    private void ShowAbout()
    {
        Console.Clear();
        Console.WriteLine("About this game:");
        Console.WriteLine("This is a simple game loop demonstration.");
        Console.WriteLine("Press any key to go back to the menu...");
        Console.ReadKey();
        ShowMenu();
    }
}

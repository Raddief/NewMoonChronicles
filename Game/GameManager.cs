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
        Console.WriteLine("  _   _                 __  __                          ");
        Console.WriteLine(" | \\ | |               |  \\/  |                         ");
        Console.WriteLine(" |  \\| | ___  _   _ ___| \\  / | ___ _ __  _   _  ___    ");
        Console.WriteLine(" | . ` |/ _ \\| | | / __| |\\/| |/ _ \\ '_ \\| | | |/ _ \\ ");
        Console.WriteLine(" | |\\  | (_) | |_| \\__ \\ |  | |  __/ | | | |_| |  __/ ");
        Console.WriteLine(" |_| \\_|\\___/ \\__,_|___/_|  |_|\\___|_| |_|\\__,_|\\___|");
        Console.WriteLine("=======================================================");
        Console.WriteLine("           An RPG Adventure Awaits on the Moon!         ");
        Console.WriteLine();
        Console.WriteLine("Welcome to New Moon Chronicles!");
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

        Console.Write("Loading New Moon Chronicles");

        for (int i = 0; i < 5; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }

        Console.WriteLine("\n\nGame loaded! Press any key to start.");
        Console.ReadKey();

        Console.Clear();

        gameLoop.Start();
    }

    private void ShowAbout()
    {
        Console.Clear();
        Console.WriteLine("About this game:\n");
        Console.WriteLine("New Moon Chronicles is an immersive RPG experience that blends the strategic");
        Console.WriteLine("depth of dungeon crawlers with the high-stakes action of a sci-fi epic.");
        Console.WriteLine("Set in a hostile alien world, players take on the role of a daring space");
        Console.WriteLine("explorer who must navigate treacherous environments, battle powerful");
        Console.WriteLine("extraterrestrial foes, and rescue their captured ally.");
        Console.WriteLine();
        Console.WriteLine("Key Features:");
        Console.WriteLine("- Alien Dungeon-Crawling Adventure: Explore procedurally generated dungeons");
        Console.WriteLine("  teeming with alien life, hidden traps, and valuable resources.");
        Console.WriteLine("- Dynamic Combat System: Engage in fast-paced, turn-based battles where");
        Console.WriteLine("  strategy is as important as strength.");
        Console.WriteLine("- Character Customization: Tailor your character’s skills and gear to");
        Console.WriteLine("  suit your playstyle, specializing in brute force, stealth, or advanced technology.");
        Console.WriteLine("- Save Your Ally: Track down your missing crew member to ensure your safe");
        Console.WriteLine("  return to Earth.");
        Console.WriteLine("- Atmospheric Sci-Fi Setting: Experience a richly detailed alien world, from");
        Console.WriteLine("  desolate moon surfaces to labyrinthine underground caverns filled with secrets.");
        Console.WriteLine("- Resource Management and Upgrades: Gather alien tech to upgrade gear, craft");
        Console.WriteLine("  new items, and fortify defenses against increasingly dangerous foes.");
        Console.WriteLine();
        Console.WriteLine("Embark on a perilous journey in New Moon Chronicles. The fate of your");
        Console.WriteLine("crew—and possibly humanity—rests in your hands.");
        Console.WriteLine("\nPress any key to go back to the menu...");
        Console.ReadKey();
        ShowMenu();
    }
}

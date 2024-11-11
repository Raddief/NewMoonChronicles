public class GameManager
{
    private GameLoop gameLoop;

    public void Run()
    {
        Initialize();
        gameLoop.Start();
    }

    private void Initialize()
    {
        gameLoop = new GameLoop();
        Console.WriteLine("Welcome to the CLI Game!");
    }
}

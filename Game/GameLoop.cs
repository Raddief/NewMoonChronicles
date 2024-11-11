public class GameLoop
{
    public void Start()
    {
        while (true)
        {
            Update();
            Render();
        }
    }

    private void Update()
    {
        Console.WriteLine("Astronaut A and B are on the moon.");
        Console.ReadKey();
    }

    private void Render()
    {
        Console.Clear();
    }
}

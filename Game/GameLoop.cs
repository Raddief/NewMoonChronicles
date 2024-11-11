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
        // Game logic
    }

    private void Render()
    {
        // Display game state
    }
}

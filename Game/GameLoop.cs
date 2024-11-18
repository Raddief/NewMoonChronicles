public class GameLoop
{
    private Player _player;
    private List<string> _storyLines = new List<string>();
    private int _currentLineIndex = 0;
    private CoreEvent _coreEvent;

    public GameLoop()
    {
        _coreEvent = new CoreEvent();
    }
    public void Start()
    {
        LoadStoryLines("Data/Levels.txt");

        while (true)
        {
            Update();
            Render();
        }
    }

    private void InitializePlayer()
    {
        GameInitializer initializer = new GameInitializer();
        _player = initializer.InitializePlayer();
    }

    private void Update()
    {
        if (_currentLineIndex < _storyLines.Count)
        {
            string line = _storyLines[_currentLineIndex];
            if (line.StartsWith("MAINEVENT"))
            {
                ExecuteCoreEvent(line);
            }
            else
            {
                Console.WriteLine(line);
            }
            _currentLineIndex++;
        }
        else
        {
            Console.WriteLine("End of story.");
        }
        Console.ReadKey();
    }

    private void Render()
    {
        Console.Clear();
    }

    private void LoadStoryLines(string filePath)
    {
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lines[i]) && !lines[i].StartsWith("//"))
                {
                    if (lines[i].StartsWith("MAINEVENT"))
                    {
                        ExecuteCoreEvent(lines[i]);
                    }
                    else
                    {
                        _storyLines.Add(lines[i]);
                    }
                }
            }
        }
    }

    private void ExecuteCoreEvent(string eventLine)
    {
        if (eventLine.Contains("PICK_ARCHETYPE"))
        {
            _player = _coreEvent.PickArchetype();
        }
        // Add more core events as needed
    }
}
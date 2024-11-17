using System;
using System.Collections.Generic;
using System.IO;

public class GameLoop
{
    private List<string> _storyLines;
    private int _currentLineIndex = 0;

    public GameLoop()
    {
        _storyLines = new List<string>();
        LoadStoryLines("Data/Levels.txt");
    }

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
        if (_currentLineIndex < _storyLines.Count)
        {
            Console.WriteLine(_storyLines[_currentLineIndex]);
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
                    // Skip level number and line number
                    i += 2;
                    if (i < lines.Length && !string.IsNullOrWhiteSpace(lines[i]))
                    {
                        _storyLines.Add(lines[i]);
                    }
                }
            }
        }
    }
}
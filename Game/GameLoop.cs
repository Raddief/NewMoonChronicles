using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Story
{
    public int id { get; set; }
    public string? content { get; set; }
    public string? eventName { get; set; }
}

public class StoryCollection
{
    public List<Story>? stories { get; set; }
}

public class GameLoop
{
    private int currentStoryId;
    private Player? player;
    private CoreEvent? coreEvent;
    private int i = 1;

    private GameState? gameState;

    public void Start()
    {
        player = new Player("Player", 0, 0, 0, 0, 0, 0, new Inventory());
        while (true)
        {
            Update(i);
            Render();
            i++;
        }
    }

    private void Update(int i)
    {
        currentStoryId = i;
        LoadStory("Data/Story.json", currentStoryId);
        Console.ReadKey();
    }

    private void Render()
    {
        Console.Clear();
    }

    private void LoadStory(string jsonPath, int id)
    {
        string jsonString = File.ReadAllText(jsonPath);

        StoryCollection? storyCollection = JsonSerializer.Deserialize<StoryCollection>(jsonString);

        if (storyCollection != null && storyCollection.stories != null)
        {
            foreach (Story story in storyCollection.stories)
            {
                if (story.id == id)
                {
                    Console.WriteLine(story.content);
                    if (story.eventName != null && player != null)
                    {
                        coreEvent = new CoreEvent(player);
                        if (story.eventName == "PICK_ARCHETYPE")
                        {
                            player = coreEvent.PickArchetype();
                        }
                        else if (story.eventName == "LEVEL_START")
                        {
                            Dictionary<int, Level> levels = LoadLevels("Data/DataLevel.json");
                            GameState gameState = new GameState(player, 1, levels);
                            gameState.Start();
                        }
                        currentStoryId = story.id + 1;
                        Console.ReadKey();
                        LoadStory(jsonPath, currentStoryId);
                        break;
                    }
                }
            }
        }
    }

    private Dictionary<int, Level> LoadLevels(string jsonPath)
    {
        string jsonString = File.ReadAllText(jsonPath);
        var levelsData = JsonSerializer.Deserialize<LevelsData>(jsonString);

        Dictionary<int, Level> levels = new Dictionary<int, Level>();
        if (levelsData != null && levelsData.levels != null)
        {
            foreach (var level in levelsData.levels)
            {
                levels.Add(level.id, level);
            }
        }

        return levels;
    }

    public class LevelsData
    {
        public List<Level> levels { get; set; }
    }
}
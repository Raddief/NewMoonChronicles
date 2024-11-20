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

    private Dictionary<int, Level> levels;
    private int currentLevel;

    public GameLoop()
    {
        levels = LoadLevels("Data/DataLevel.json");
    }

    public void Start()
    {
        player = new Player("Player", 0, 0, 0, 0, 0, 0, new Inventory(), new Equipment());
        if (File.Exists("savegame.txt"))
        {
            Console.WriteLine("Do you want to load the saved game? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                LoadGame("savegame.txt", levels);
                GameState gameState = new GameState(player, currentLevel, levels);
                gameState.Start();
            }
        }
        while (true)
        {
            Console.Clear();
            Update(i);
            i++;
        }
    }

    private void Update(int i)
    {
        currentStoryId = i;
        LoadStory("Data/Story.json", currentStoryId);
        Console.ReadKey();
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
                            GameState gameState = new GameState(player, 1, levels);
                            gameState.Start();
                        }
                        currentStoryId = story.id + 1;
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
        public List<Level>? levels { get; set; }
    }

    public void LoadGame(string filePath, Dictionary<int, Level> levels)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            // Read the plain text file
            var lines = File.ReadAllLines(filePath);
            bool readingInventory = false;
            bool readingEquipment = false;

            foreach (var line in lines)
            {
                // Check for section headers
                if (line == "[Inventory]")
                {
                    readingInventory = true;
                    readingEquipment = false;
                    continue;
                }
                else if (line == "[Equipment]")
                {
                    readingInventory = false;
                    readingEquipment = true;
                    continue;
                }

                if (readingInventory)
                {
                    // Parse inventory items
                    var itemData = line.Split(',');
                    if (itemData.Length == 4)
                    {
                        string name = itemData[0];
                        string description = itemData[1];
                        int quantity = int.Parse(itemData[2]);
                        int value = int.Parse(itemData[3]);

                        player.Inventory.AddItem(new Item(name, description, quantity, value));
                    }
                }
                else if (readingEquipment)
                {
                    // Parse equipment items
                    var itemData = line.Split(',');
                    if (itemData.Length == 4)
                    {
                        string name = itemData[0];
                        string description = itemData[1];
                        int quantity = int.Parse(itemData[2]);
                        int value = int.Parse(itemData[3]);

                        player.Equipment.AddItem(new Item(name, description, quantity, value));
                    }
                }
                else
                {
                    // Parse player stats and game state
                    var keyValue = line.Split('=');
                    if (keyValue.Length != 2) continue;

                    var key = keyValue[0];
                    var value = keyValue[1];

                    switch (key)
                    {
                        case "PlayerName":
                            player.Stats.Name = value;
                            break;
                        case "Health":
                            player.Stats.HealthPoint = int.Parse(value);
                            break;
                        case "MaxHealth":
                            player.Stats.MaxHealthPoint = int.Parse(value);
                            break;
                        case "AttackPower":
                            player.Stats.AttackPower = int.Parse(value);
                            break;
                        case "DefensePoint":
                            player.Stats.DefensePoint = int.Parse(value);
                            break;
                        case "Agility":
                            player.Stats.Agility = int.Parse(value);
                            break;
                        case "Experience":
                            player.Stats.Experience = int.Parse(value);
                            break;
                        case "Level":
                            player.Stats.Level = int.Parse(value);
                            break;
                        case "CurrentLevel":
                            currentLevel = int.Parse(value);
                            break;
                    }
                }
            }

            Console.WriteLine("Game loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load game: {ex.Message}");
        }
    }
}
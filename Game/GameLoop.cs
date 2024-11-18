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

    public void Start()
    {
        player = new Player("Player", 0, 0, 0, 0, 0, 0);
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
                        currentStoryId = story.id + 1;
                        Console.ReadKey();
                        LoadStory(jsonPath, currentStoryId);
                        break;
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;

public class GameState
{
    private Player player;
    private int currentLevel;
    private Dictionary<int, Level> levels;

    public GameState(Player player, int currentLevel, Dictionary<int, Level> levels)
    {
        this.player = player;
        this.currentLevel = currentLevel;
        this.levels = levels;
    }

    public void Start()
    {
        while (true)
        {
            Level currentLevelData = levels[currentLevel];
            Console.WriteLine(currentLevelData.description);

            foreach (var option in currentLevelData.options)
            {
                Console.WriteLine($"{option.id}. {option.action} - {option.description}");
            }

            Console.Write("Choose an action: ");
            if (int.TryParse(Console.ReadLine(), out int actionId))
            {
                var selectedOption = currentLevelData.options.Find(o => o.id == actionId);
                if (selectedOption != null)
                {
                    HandleAction(selectedOption);
                }
                else
                {
                    Console.WriteLine("Invalid action. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            // Check if the stage has changed
            if (currentLevelData.id != currentLevel)
            {
                break;
            }
        }
    }

    private void HandleAction(Option option)
    {
        Random random = new Random();
        int roll = random.Next(100);

        int cumulativeChance = 0;
        foreach (var feedback in option.feedback)
        {
            cumulativeChance += feedback.chance;
            if (roll < cumulativeChance)
            {
                Console.WriteLine(feedback.result);
                HandleFlag(feedback.flag, feedback.nextStageId);
                break;
            }
        }
    }

    private void HandleFlag(string flag, string? nextStageId)
    {
        switch (flag)
        {
            case "nothing":
                // Handle nothing found
                break;
            case "moon_bug":
                // Handle finding a moon bug
                break;
            case "penny":
                // Handle finding a penny
                break;
            case "move_stage":
                // Handle moving to the next stage
                if (nextStageId != null)
                {
                    currentLevel = int.Parse(nextStageId);
                }
                break;
            case "silence":
                // Handle silence
                break;
            default:
                // Handle unknown flag
                break;
        }
    }
}

public class Level
{
    public int id { get; set; }
    public string description { get; set; }
    public List<Option> options { get; set; }
}

public class Option
{
    public int id { get; set; }
    public string action { get; set; }
    public string description { get; set; }
    public List<Feedback> feedback { get; set; }
}

public class Feedback
{
    public int chance { get; set; }
    public string result { get; set; }
    public string flag { get; set; }
    public string? nextStageId { get; set; }
}
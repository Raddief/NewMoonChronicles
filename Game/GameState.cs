using System;
using System.Collections.Generic;

public class GameState
{
    private Player player;
    private int currentLevel;
    private Dictionary<int, Level> levels;

    private CombatSystem combatSystem;

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
            DisplayCurrentLevel();
        }
    }

    private void DisplayCurrentLevel()
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

        // Wait for the user to press a key before clearing the screen
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
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
                HandleFlag(feedback.flag, feedback.nextStageId, feedback);
                break;
            }
        }
    }

    private void HandleFlag(string flag, string? nextStageId, Feedback feedback)
    {
        switch (flag)
        {
            case "nothing":
                // Handle nothing found
                break;
            case "moon_bug":
                // Handle finding a moon bug
                Item moonBug = new Item("Moon Bug", "A rare moon bug.", 1, 5);
                player.Inventory.AddItem(moonBug);
                Console.WriteLine("You found a moon bug and added it to your inventory.");
                break;
            case "penny":
                // Handle finding a penny
                Item penny = new Item("Penny", "A shiny penny.", 1, 1);
                player.Inventory.AddItem(penny);
                Console.WriteLine("You found a penny and added it to your inventory.");
                break;
            case "move_stage":
                // Handle moving to the next stage
                if (nextStageId != null)
                {
                    currentLevel = int.Parse(nextStageId);
                }
                break;
            case "check_inv":
                // Handle checking inventory
                player.Inventory.ListItems();
                break;
            case "open_shop":
                // Handle opening the shop
                Shop shop = new Shop();
                shop.DisplayShop(player);
                break;
            case "combat":
                // Handle combat
                if (feedback != null)
                {
                    string entityName = feedback.entityName ?? "Unknown";
                    int hp = feedback.hp ?? 50;
                    int attack = feedback.attack ?? 40;
                    int defense = feedback.defense ?? 5;
                    int agility = feedback.agility ?? 5;
                    int experience = feedback.experience ?? 0;
                    int level = feedback.level ?? 1;
                    int gold = feedback.gold ?? 0;

                    Enemy enemy = new Enemy(entityName, hp, attack, defense, agility, experience, level);
                    CombatSystem combatSystem = new CombatSystem();
                    combatSystem.StartCombat(player, enemy);

                    if (enemy.Stats.HealthPoint <= 0)
                    {
                        Item goldItem = new Item("Penny", "Currency", gold, 1);
                        player.Inventory.AddItem(goldItem);
                        Console.WriteLine($"You obtained {gold} pennies.");
                    }
                }
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
    public string? entityName { get; set; }
    public int? hp { get; set; }
    public int? attack { get; set; }
    public int? defense { get; set; }
    public int? agility { get; set; }
    public int? experience { get; set; }
    public int? level { get; set; }
    public int? gold { get; set; }
}
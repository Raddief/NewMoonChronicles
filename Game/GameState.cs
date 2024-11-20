using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine("Press 'S' to save or any other key to continue...");
            var input = Console.ReadKey(true).Key;

            if (input == ConsoleKey.S)
            {
                SaveGame("savegame.txt");
            }
            else
            {
                DisplayCurrentLevel();
            }
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
            case "get_item":
                Random random = new Random();
                int chance = random.Next(1, 101); // Generates a number between 1 and 100

                if (chance <= 60) // 60% chance to find a Moon Bug
                {
                    Item moonBug = new Item("Moon Bug", "A rare moon bug.", 1, 5);
                    player.Inventory.AddItem(moonBug);
                    Console.WriteLine("You found a Moon Bug and added it to your inventory.");
                }
                else if (chance <= 99) // 39% chance to find a Penny
                {
                    Item penny = new Item("Penny", "A shiny penny. Gotta worth something!", 1, 1);
                    player.Inventory.AddItem(penny);
                    Console.WriteLine("You found a Penny and added it to your inventory.");
                }
                else if (chance <= 100) // 1% chance to find a Blood Sword
                {
                    Item bloodSword = new Item("Blood Sword", "A dangerous sword.", 1, 10);
                    player.Equipment.AddItem(bloodSword);
                    Console.WriteLine("You found a Blood Sword and added it to your inventory.");
                }
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
                player.Inventory.ListItem();
                break;
            case "check_equip":
                // Handle checking equipment
                player.Equipment.ListItem(player);
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

    public void SaveGame(string filePath)
    {
        try
        {
            // Construct save data as plain text
            var saveData = new StringBuilder();
            saveData.AppendLine($"PlayerName={player.Stats.Name}");
            saveData.AppendLine($"Health={player.Stats.HealthPoint}");
            saveData.AppendLine($"MaxHealth={player.Stats.MaxHealthPoint}");
            saveData.AppendLine($"AttackPower={player.Stats.AttackPower}");
            saveData.AppendLine($"DefensePoint={player.Stats.DefensePoint}");
            saveData.AppendLine($"Agility={player.Stats.Agility}");
            saveData.AppendLine($"Experience={player.Stats.Experience}");
            saveData.AppendLine($"Level={player.Stats.Level}");
            saveData.AppendLine($"CurrentLevel={currentLevel}");

            // Inventory items
            saveData.AppendLine("[Inventory]");
            foreach (var item in player.Inventory.items)
            {
                saveData.AppendLine($"{item.Name},{item.Description},{item.Quantity},{item.Price}");
            }

            // Equipment items
            saveData.AppendLine("[Equipment]");
            foreach (var equipment in player.Equipment.items)
            {
                saveData.AppendLine($"{equipment.Name},{equipment.Description},{equipment.Quantity},{equipment.Price}");
            }

            // Write to file
            File.WriteAllText(filePath, saveData.ToString());
            Console.WriteLine("Game saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save game: {ex.Message}");
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
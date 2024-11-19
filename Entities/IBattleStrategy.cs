using System;

public interface IBattleStrategy
{
    void Execute(Player player, Enemy enemy);
}

public class FightStrategy : IBattleStrategy
{
    public void Execute(Player player, Enemy enemy)
    {
        CombatSystem combatSystem = new CombatSystem();
        int damage = combatSystem.CalculateDamage(player.Stats.AttackPower, enemy.Stats.DefensePoint);
        Console.WriteLine($"Player attacks the enemy, dealing {damage} damage!");
        enemy.TakeDamage(damage);

        // Grant experience to the player
        if (enemy.Stats.HealthPoint <= 0)
        {
            Console.WriteLine("Enemy defeated! Player gains experience.");
            player.Stats.GainExperience(enemy.Stats.Level * 50); // Example XP gain
        }
    }
}

public class RunStrategy : IBattleStrategy
{
    public void Execute(Player player, Enemy enemy)
    {
        CombatSystem combatSystem = new CombatSystem();
        if (combatSystem.CanEscape(player.Stats.Agility, enemy.Stats.Agility))
        {
            Console.WriteLine("Player successfully escapes!");
            // Escape logic, e.g., end the battle (set a flag or exit the loop)
        }
        else
        {
            Console.WriteLine("Player fails to escape! The enemy counterattacks!");
            int counterAttackDamage = combatSystem.CalculateDamage(enemy.Stats.AttackPower, player.Stats.DefensePoint);
            player.TakeDamage(counterAttackDamage);
        }
    }
}


public class NegotiateStrategy : IBattleStrategy
{
    public void Execute(Player player, Enemy enemy)
    {
        Random random = new Random();
        int chance = random.Next(100);
        if (chance < 30)
        {
            Console.WriteLine("The enemy agrees to negotiate and leaves peacefully.");
        }
        else
        {
            Console.WriteLine("Negotiation fails! The enemy counterattacks!");
            int retaliationDamage = enemy.Stats.AttackPower / 2;
            player.TakeDamage(retaliationDamage);
        }
    }
}

public class ItemStrategy : IBattleStrategy
{
    public bool IsCanceled { get; private set; } = false;

    public void Execute(Player player, Enemy enemy)
    {
        Console.WriteLine("Choose an item to use (0 to cancel):");
        List<Item> items = player.Inventory.GetItems();

        if (items.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            IsCanceled = true;
            return;
        }

        // Display items
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name} (x{items[i].Quantity}) - {items[i].Description}");
        }

        Console.Write("Enter the number of the item to use: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int choice))
        {
            if (choice == 0)
            {
                Console.WriteLine("Cancelled item usage.");
                IsCanceled = true;
                return;
            }

            if (choice > 0 && choice <= items.Count)
            {
                Item selectedItem = items[choice - 1];
                selectedItem.Use(player); // Pass the Player object to apply the effect
                player.Inventory.RemoveItem(selectedItem.Name, 1);
                IsCanceled = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. No item used.");
                IsCanceled = true;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. No item used.");
            IsCanceled = true;
        }
    }
}

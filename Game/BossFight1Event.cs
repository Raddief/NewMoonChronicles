public class BossFightEvent
{
    private Player player;
    private Enemy boss;
    private int turnCounter;
    private bool hasHealed = false;

    public BossFightEvent(Player player, Enemy boss)
    {
        this.player = player;
        this.boss = boss;
        this.turnCounter = 1;
    }

    public void StartBossFight()
    {
        Console.WriteLine("A sinister aura fills the air...");
        Console.WriteLine($"You encounter {boss.Stats.Name}, a fearsome looking monster that is looking sharply at you! A fight is imminent.");

        PreBattleChoice();

        CombatSystem combatSystem = new CombatSystem();

        // Battle loop
        while (player.Stats.HealthPoint > 0 && boss.Stats.HealthPoint > 0)
        {
            // Player's turn
            combatSystem.ExecutePlayerTurn(player, boss);

            if (boss.Stats.HealthPoint <= 0)
            {
                Console.WriteLine($"You have triumphed over {boss.Stats.Name}!");
                return;
            }

            // Boss's turn
            ExecuteBossTurn(combatSystem);

            if (player.Stats.HealthPoint <= 0)
            {
                Console.WriteLine($"You were defeated by {boss.Stats.Name}...");
                return;
            }

            turnCounter++;
        }
    }

    private void PreBattleChoice()
    {
        Console.WriteLine("\nBefore the fight begins, you have an important decision to make:");
        Console.WriteLine("1. Charge in recklessly (+10 Attack, -10 Defense)");
        Console.WriteLine("2. Fortify yourself (+10 Defense, -10 Attack)");
        Console.WriteLine("3. Observe and strategize (No stat changes)");

        while (true)
        {
            Console.Write("Your choice: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        player.Stats.AttackPower += 10;
                        player.Stats.DefensePoint -= 10;
                        Console.WriteLine("You feel a surge of aggression, ready to deal devastating blows.");
                        return;
                    case 2:
                        player.Stats.DefensePoint += 10;
                        player.Stats.AttackPower -= 10;
                        Console.WriteLine("You steady yourself, bracing for the boss's powerful attacks.");
                        return;
                    case 3:
                        Console.WriteLine("You carefully analyze the situation, opting for balance.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private void ExecuteBossTurn(CombatSystem combatSystem)
    {
        Console.WriteLine($"\n{boss.Stats.Name}'s turn!");

        if (turnCounter % 3 == 0) // Special move every 3 turns
        {
            ExecuteSpecialMove();
        }
        else if (boss.Stats.HealthPoint < boss.Stats.MaxHealthPoint / 2 && !hasHealed) // Heal at 50% HP
        {
            HealBoss();
            hasHealed = true;
        }
        else
        {
            // Normal attack
            int damage = combatSystem.CalculateDamage(boss.Stats.AttackPower, player.Stats.DefensePoint);
            player.TakeDamage(damage);
            Console.WriteLine($"{boss.Stats.Name} attacks and deals {damage} damage!");
        }
    }

    private void ExecuteSpecialMove()
    {
        Console.WriteLine($"{boss.Stats.Name} unleashes a devastating special attack!");
        int damage = boss.Stats.AttackPower * 2; // Double the normal attack power
        player.TakeDamage(damage);
        Console.WriteLine($"The special attack deals {damage} damage!");
    }

    private void HealBoss()
    {
        int healAmount = boss.Stats.MaxHealthPoint / 4; // Heal 25% of max HP
        boss.Stats.HealthPoint += healAmount;
        if (boss.Stats.HealthPoint > boss.Stats.MaxHealthPoint)
        {
            boss.Stats.HealthPoint = boss.Stats.MaxHealthPoint;
        }
        Console.WriteLine($"{boss.Stats.Name} heals for {healAmount} HP! Current HP: {boss.Stats.HealthPoint}/{boss.Stats.MaxHealthPoint}");
    }
}
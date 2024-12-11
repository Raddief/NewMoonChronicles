public class CombatSystem
{
    private bool battleEnded;

    public void StartCombat(Player player, Enemy enemy)
    {
        battleEnded = false;

        Console.WriteLine("Battle Start!");
        Console.WriteLine($"Player: {player.Stats.Name}, HP: {player.Stats.HealthPoint}, Level: {player.Stats.Level}");
        Console.WriteLine($"Enemy: {enemy.Stats.Name}, HP: {enemy.Stats.HealthPoint}, Level: {enemy.Stats.Level}");

        while (player.Stats.HealthPoint > 0 && enemy.Stats.HealthPoint > 0 && !battleEnded)
        {
            ExecutePlayerTurn(player, enemy);

            // Update skill cooldowns after player's turn
            player.UpdateSkillCooldowns();
            
            if (enemy.Stats.HealthPoint <= 0)
            {
                Console.WriteLine("\nVictory! The enemy has been defeated.");
                break;
            }

            if (battleEnded)
            {
                break;
            }

            ExecuteEnemyTurn(player, enemy);

            if (player.Stats.HealthPoint <= 0)
            {
                Console.WriteLine("\nGame Over! The player has been defeated.");
                break;
            }
        }

        Console.WriteLine("Battle End!");
        Console.WriteLine($"Player Final HP: {player.Stats.HealthPoint}, Level: {player.Stats.Level}");
        if (enemy.Stats.HealthPoint > 0)
        {
            Console.WriteLine($"Enemy Final HP: {enemy.Stats.HealthPoint}");
        }
    }

    public void ExecutePlayerTurn(Player player, Enemy enemy)
    {
        while (true) // Loop until a valid action is performed
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");
            Console.WriteLine("3. Use Item");
            Console.WriteLine("4. Negotiate");
            Console.WriteLine("5. Use Skill");
            Console.Write("Your choice: ");
            string? choice = Console.ReadLine();

            IBattleStrategy? selectedStrategy = choice switch
            {
                "1" => new FightStrategy(),
                "2" => new RunStrategy(),
                "3" => new ItemStrategy(),
                "4" => new NegotiateStrategy(),
                "5" => new SkillStrategy(),
                _ => null
            };

            if (selectedStrategy == null)
            {
                Console.WriteLine("Invalid choice! Try again.");
                continue; // Retry the menu
            }

            if (selectedStrategy is ItemStrategy itemStrategy)
            {
                Console.WriteLine("Executing player's action...");
                itemStrategy.Execute(player, enemy);
                if (itemStrategy.IsCanceled)
                {
                    Console.WriteLine("Returning to main menu...");
                    continue; // Return to the menu
                }
            }
            else
            {
                Console.WriteLine("Executing player's action...");
                selectedStrategy.Execute(player, enemy);

                if (selectedStrategy is RunStrategy runStrategy && runStrategy.HasEscaped)
                {
                    Console.WriteLine("You successfully escaped!");
                    battleEnded = true;
                }
                else if (selectedStrategy is NegotiateStrategy negotiateStrategy && negotiateStrategy.HasNegotiated)
                {
                    Console.WriteLine("You successfully negotiated with the enemy!");
                    battleEnded = true;
                }
            }

            break; // Exit the loop once a valid action is performed
        }
    }

    private void ExecuteEnemyTurn(Player player, Enemy enemy)
    {
        Console.WriteLine("\nThe enemy attacks!");
        int enemyDamage = CalculateDamage(enemy.Stats.AttackPower, player.Stats.DefensePoint);
        player.TakeDamage(enemyDamage);
    }

    public int CalculateDamage(int attackerAttack, int defenderDefense)
    {
        int damage = attackerAttack - defenderDefense;
        return Math.Max(damage, 0); // Ensure no negative damage
    }

    public bool CanEscape(int playerAgility, int enemyAgility)
    {
        Random random = new Random();
        int playerRoll = random.Next(1, playerAgility + 1);
        int enemyRoll = random.Next(1, enemyAgility + 1);
        return playerRoll > enemyRoll;
    }
    // Di dalam CombatSystem atau Player class

}

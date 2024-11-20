public class CoreEvent
{
    private Player player;

    public CoreEvent(Player player)
    {
        this.player = player;
    }

    public Player PickArchetype()
    {
        while (true)
        {
            Console.WriteLine("(suddenly you remember your past life) What's your identity?");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Rogue");
            Console.Write("\nChoose your identity: ");

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        player.Stats = new EntityStats("Warrior", 150, 75, 50, 30, 0, 1);
                        break;
                    case 2:
                        player.Stats = new EntityStats("Mage", 100, 120, 20, 40, 0, 1);
                        break;
                    case 3:
                        player.Stats = new EntityStats("Rogue", 120, 90, 40, 80, 0, 1);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        Console.WriteLine("\n##########################################");
        Console.WriteLine("#            Identity Obtained!          #");
        Console.WriteLine("##########################################");
        Console.WriteLine("# Name        : " + player.Stats.Name.PadRight(25) + "#");
        Console.WriteLine("# Vitality    : " + player.Stats.HealthPoint.ToString().PadRight(25) + "#");
        Console.WriteLine("# Strength    : " + player.Stats.AttackPower.ToString().PadRight(25) + "#");
        Console.WriteLine("# Fortitude   : " + player.Stats.DefensePoint.ToString().PadRight(25) + "#");
        Console.WriteLine("# Agility     : " + player.Stats.Agility.ToString().PadRight(25) + "#");
        Console.WriteLine("# Experience  : " + player.Stats.Experience.ToString().PadRight(25) + "#");
        Console.WriteLine("# Level       : " + player.Stats.Level.ToString().PadRight(25) + "#");
        Console.WriteLine("##########################################");

        return player;
    }
}
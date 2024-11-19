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
            Console.WriteLine("What's your identity? ");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Rogue");

            string input = Console.ReadLine();

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
                break; // Exit the loop if a valid choice is made
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        return player;
    }
}
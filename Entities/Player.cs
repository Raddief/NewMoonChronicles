public class Player : Entity
{

    public Inventory Inventory { get; set; }
    public Player(string name, int health, int attack, int defense, int speed, int experience, int level, Inventory inventory) : base(name, health, attack, defense, speed, experience, level)
    {
        Inventory = inventory;
    }
    public void Move(string direction)
    {
        Console.WriteLine($"Player moves {direction}");
    }
}

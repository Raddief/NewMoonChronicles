public class Player : Entity
{
    public Inventory Inventory { get; private set; }

    public Player(string name, int health, int attack, int defense, int agility, int experience, int level)
        : base(name, health, attack, defense, agility, experience, level)
    {
        Inventory = new Inventory();
    }

    public void Heal(int healing)
    {
        Stats.HealthPoint += healing;
        if (Stats.HealthPoint > Stats.MaxHealthPoint)
        {
            Stats.HealthPoint = Stats.MaxHealthPoint;
        }
        Console.WriteLine($"Player heals for {healing} HP! Current HP: {Stats.HealthPoint}/{Stats.MaxHealthPoint}");
    }
}

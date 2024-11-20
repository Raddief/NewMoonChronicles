public class Player : Entity
{
    public Inventory Inventory { get; set; }
    public Equipment Equipment { get; set; }

    public Player(string name, int health, int attack, int defense, int agility, int experience, int level, Inventory inventory, Equipment equipment)
        : base(name, health, attack, defense, agility, experience, level)
    {
        Inventory = inventory;
        Equipment = equipment;
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

    public void changeAttack(int attack)
    {
        if (attack < 0)
        {
            Stats.AttackPower += attack;
            Console.WriteLine("Player has no weapon now.");
        }
        else
        {
            Stats.AttackPower += attack;
            Console.WriteLine($"Player got {attack} attack damage! Current attack: {Stats.AttackPower}");
        }
    }
}

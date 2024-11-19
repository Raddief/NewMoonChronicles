public abstract class Entity
{
    public EntityStats Stats { get; private set; }

    public Entity(string name, int health, int attack, int defense, int agility, int experience, int level)
    {
        Stats = new EntityStats(name, health, attack, defense, agility, experience, level);
    }

    public void TakeDamage(int damage)
    {
        Stats.HealthPoint -= damage;
        Stats.HealthPoint = Math.Max(Stats.HealthPoint, 0);
        Console.WriteLine($"{Stats.Name} takes {damage} damage! Remaining HP: {Stats.HealthPoint}");
    }
}

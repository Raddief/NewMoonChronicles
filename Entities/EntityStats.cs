public class EntityStats
{
    public string Name { get; set; }
    public int HealthPoint { get; set; }
    public int MaxHealthPoint { get; set; }
    public int AttackPower { get; set; }
    public int DefensePoint { get; set; }
    public int Agility { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }

    public EntityStats(string name, int healthPoint, int attackPower, int defensePoint, int agility, int experience, int level)
    {
        Name = name;
        HealthPoint = healthPoint;
        MaxHealthPoint = healthPoint; // Initial max health equals starting health
        AttackPower = attackPower;
        DefensePoint = defensePoint;
        Agility = agility;
        Experience = experience;
        Level = level;
    }

    public void GainExperience(int xp)
    {
        Experience += xp;
        while (Experience >= ExperienceToNextLevel())
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Experience -= ExperienceToNextLevel();
        Level++;

        // Increase stats on level up
        MaxHealthPoint += 10;
        HealthPoint = MaxHealthPoint; // Fully heal on level up
        AttackPower += 5;
        DefensePoint += 5;
        Agility += 2;
    }

    private int ExperienceToNextLevel()
    {
        return Level * 100; // Example: next level requires 100 XP per level
    }
}
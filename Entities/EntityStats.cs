using System;

[Serializable]
public class EntityStats
{
    public string Name { get; private set; }
    public int HealthPoint { get; set; }
    public int AttackPower { get; private set; }
    public int DefensePoint { get; private set; }
    public int Agility { get; private set; }
    public int Experience { get; private set; }
    public int Level { get; private set; }

    public EntityStats(string name, int healthPoint, int attackPower, int defensePoint, int agility, int experience, int level)
    {
        Name = name;
        HealthPoint = healthPoint;
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
        HealthPoint += 10;
        AttackPower += 5;
        DefensePoint += 5;
        Agility += 2;
    }

    private int ExperienceToNextLevel()
    {
        return Level * 100; // Example: next level requires 100 XP per level
    }
}
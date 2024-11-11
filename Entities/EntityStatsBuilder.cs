public class EntityStatsBuilder
{
    private string name;
    private int healthPoint;
    private int attackPower;
    private int defensePoint;
    private int agility;
    private int experience;
    private int level;

    public EntityStatsBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }

    public EntityStatsBuilder SetHealthPoint(int healthPoint)
    {
        this.healthPoint = healthPoint;
        return this;
    }

    public EntityStatsBuilder SetAttackPower(int attackPower)
    {
        this.attackPower = attackPower;
        return this;
    }

    public EntityStatsBuilder SetDefensePoint(int defensePoint)
    {
        this.defensePoint = defensePoint;
        return this;
    }

    public EntityStatsBuilder SetAgility(int agility)
    {
        this.agility = agility;
        return this;
    }

    public EntityStatsBuilder SetExperience(int experience)
    {
        this.experience = experience;
        return this;
    }

    public EntityStatsBuilder SetLevel(int level)
    {
        this.level = level;
        return this;
    }

    public EntityStats Build()
    {
        return new EntityStats(name, healthPoint, attackPower, defensePoint, agility, experience, level);
    }
}
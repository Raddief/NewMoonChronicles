public class EntityDirector
{
    private readonly EntityStatsBuilder _builder;

    public EntityDirector(EntityStatsBuilder builder)
    {
        _builder = builder;
    }

    public EntityStats ConstructWarrior()
    {
        return _builder
            .SetName("Warrior")
            .SetHealthPoint(150)
            .SetAttackPower(75)
            .SetDefensePoint(50)
            .SetAgility(30)
            .SetExperience(0)
            .SetLevel(1)
            .Build();
    }

    public EntityStats ConstructMage()
    {
        return _builder
            .SetName("Mage")
            .SetHealthPoint(100)
            .SetAttackPower(120)
            .SetDefensePoint(20)
            .SetAgility(40)
            .SetExperience(0)
            .SetLevel(1)
            .Build();
    }

    public EntityStats ConstructRogue()
    {
        return _builder
            .SetName("Rogue")
            .SetHealthPoint(120)
            .SetAttackPower(90)
            .SetDefensePoint(40)
            .SetAgility(80)
            .SetExperience(0)
            .SetLevel(1)
            .Build();
    }

    public EntityStats ConstructBoss1(){
        return _builder
            .SetName("Charybdis")
            .SetHealthPoint(400)
            .SetAttackPower(15)
            .SetDefensePoint(45)
            .SetAgility(40)
            .SetExperience(0)
            .SetLevel(1)
            .Build();
    }
}
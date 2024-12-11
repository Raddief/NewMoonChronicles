public class Player : Entity // ada yg ditambah
{
    public Inventory Inventory { get; set; }
    public Equipment Equipment { get; set; }
    public List<Skill> Skills { get; set; } 
    // Menambahkan daftar skill
    public List<BuffDebuff> ActiveEffects { get; set; } // Menambahkan daftar buff/debuff

    public Player(string name, int health, int attack, int defense, int agility, int experience, int level, Inventory inventory, Equipment equipment)
        : base(name, health, attack, defense, agility, experience, level)
    {
        Inventory = inventory;
        Equipment = equipment;
        Skills = new List<Skill>()
        {
            new Skill("Power Strike", 3),      // Skill dengan nama "Power Strike" dan cooldown 2 giliran
            new Skill("Offensive Stance", 4),  // Skill dengan nama "Defensive Stance" dan cooldown 3 giliran
            new Skill("Quick Heal", 6)         // Skill dengan nama "Quick Heal" dan cooldown 5 giliran
        };

        ActiveEffects = new List<BuffDebuff>();
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

    public void UpdateEffects()
    {
        for (int i = ActiveEffects.Count - 1; i >= 0; i--)
        {
            ActiveEffects[i].Duration--;
            if (ActiveEffects[i].Duration <= 0)
            {
                ActiveEffects[i].Remove(this);
                ActiveEffects.RemoveAt(i);
            }
        }
    }

    public void UseSkill(Skill skill, Enemy enemy)
    {
        if (skill.CanUse())
        {
            skill.Execute(this, enemy);
        }
        else
        {
            Console.WriteLine("Skill is on cooldown.");
        }
    }
    public void UpdateSkillCooldowns() 
    {
        foreach (var skill in Skills) 
        {
            skill.UpdateCooldown();
        }
    }

}

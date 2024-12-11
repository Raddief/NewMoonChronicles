public class Skill
{
    public string Name { get; private set; }
    public int BaseCooldown { get; private set; }
    public int CurrentCooldown { get; private set; }

    public Skill(string name, int cooldown)
    {
        Name = name;
        BaseCooldown = cooldown;
        CurrentCooldown = 0;
    }

    public bool CanUse()
    {
        return CurrentCooldown <= 0;
    }

    public void Execute(Player player, Enemy enemy)
    {
        // Implement skill-specific logic based on the skill name
        switch (Name)
        {
            case "Power Strike":
                PowerStrikeSkill(player, enemy);
                break;
            case "Offensive Stance":
                OffensiveStanceSkill(player); 
                break;
            case "Quick Heal":
                QuickHealSkill(player);
                break;
            default:
                Console.WriteLine($"Undefined skill: {Name}");
                break;
        }

        // Set cooldown after using the skill
        CurrentCooldown = BaseCooldown;
    }

    private void PowerStrikeSkill(Player player, Enemy enemy)
    {
        // Increased damage attack
        CombatSystem combatSystem = new CombatSystem();
        int damageMultiplier = 2;
        int damage = combatSystem.CalculateDamage(player.Stats.AttackPower * damageMultiplier, enemy.Stats.DefensePoint);
        
        Console.WriteLine($"Power Strike! Dealing {damage} damage!");
        enemy.TakeDamage(damage);
    }

    private void OffensiveStanceSkill(Player player) 
    {
        // Temporary attack boost with a specific duration
        BuffDebuff offensiveBuff = new BuffDebuff(
            "Offensive Stance", 
            2,  // Duration of 2 turns 
            10, // Increase attack by 10 
            true // It's a buff 
        );

        player.ActiveEffects.Add(offensiveBuff);
        offensiveBuff.Apply(player);
    }

    private void QuickHealSkill(Player player)
    {
        // Heal a portion of max health
        int healAmount = player.Stats.MaxHealthPoint / 4;
        player.Heal(healAmount);
        Console.WriteLine($"Quick Heal restores {healAmount} HP!");
    }

    public void UpdateCooldown()
    {
        if (CurrentCooldown > 0)
        {
            CurrentCooldown--;
        }
    }
}


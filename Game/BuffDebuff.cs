public class BuffDebuff
{
    public string Name { get; private set; }
    public int Duration { get; set; }
    public int EffectValue { get; private set; }
    public bool IsBuff { get; private set; }

    public BuffDebuff(string name, int duration, int effectValue, bool isBuff)
    {
        Name = name;
        Duration = duration;
        EffectValue = effectValue;
        IsBuff = isBuff;
    }

    public void Apply(Player player)
    {
        if (IsBuff)
        {
            player.Stats.AttackPower += EffectValue;
            Console.WriteLine($"{Name} applied! Attack increased by {EffectValue}.");
        }
        else
        {
            player.Stats.AttackPower -= EffectValue;
            Console.WriteLine($"{Name} applied! Attack decreased by {EffectValue}.");
        }
    }

    public void Remove(Player player)
    {
        if (IsBuff)
        {
            player.Stats.AttackPower -= EffectValue;
            Console.WriteLine($"{Name} removed! Attack decreased by {EffectValue}.");
        }
        else
        {
            player.Stats.AttackPower += EffectValue;
            Console.WriteLine($"{Name} removed! Attack increased by {EffectValue}.");
        }
    }
}

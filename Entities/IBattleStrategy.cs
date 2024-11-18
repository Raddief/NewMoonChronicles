public interface IBattleStrategy
{
    void Execute(Player player, Enemy enemy);
}

public class FightStrategy : IBattleStrategy
{
    public void Execute(Player player, Enemy enemy)
    {
        Console.WriteLine("Player hit the enemy with his weapon");
        enemy.TakeDamage(10)
    }
}

public class RunStrategy : IBattleStrategy
{
    public void Execute(Player player, Enemy enemy)
    {
        Console.WriteLine("Player is trying to run from the enemy. Player slipped.");
        player.TakeDamage(5);
    }
}

public class NegotiateStrategy : IBattleStrategy
{
    public void Execute(Player player, Enemy enemy)
    {
        Console.WriteLine("Player: Bang ampun bang gw cuma mau balik ke bumi");
    }
}

public class ItemStrategy : IBattleStrategy
{
    public void Execute(Player player, Enemy enemy)
    {
        Console.WriteLine("Player takes item from inventory");
        
        // Logic for taking item from inventory
        
        player.TakeDamage(-10); // Healing
    }
}

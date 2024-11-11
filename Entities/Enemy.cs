public class Enemy : Entity
{
    public void Attack(Player player)
    {
        player.TakeDamage(10);
        Console.WriteLine("Enemy attacks the player!");
    }
}

public class CombatSystem
{
    public void Fight(Player player, Enemy enemy)
    {
        player.TakeDamage(10);
        enemy.TakeDamage(5);
    }
}

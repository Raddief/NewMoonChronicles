public class Player : Entity
{

    public Player(string name, int health, int attack, int defense, int speed, int experience, int level) : base(name, health, attack, defense, speed, experience, level)
    {
    }
    public void Move(string direction)
    {
        Console.WriteLine($"Player moves {direction}");
    }
}

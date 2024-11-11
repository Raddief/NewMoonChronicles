public abstract class Entity
{
    public string Name { get; set; }
    public int Health { get; set; }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
    }
}

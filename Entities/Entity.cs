public abstract class Entity
{
    private EntityStats _stats;

    public EntityStats Stats
    {
        get { return _stats; }
        set { _stats = value; }
    }

    public Entity(string name, int healthPoint, int attackPower, int defensePoint, int agility, int experience, int level)
    {
        _stats = new EntityStats(name, healthPoint, attackPower, defensePoint, agility, experience, level);
    }

    public void TakeDamage(int damage)
    {
        _stats.HealthPoint -= damage;
        if (_stats.HealthPoint < 0)
        {
            _stats.HealthPoint = 0;
        }
    }
}

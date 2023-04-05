public class Swordsman : Enemy
{
    private readonly IParameter _health;
    private readonly int _startAttack = 5;
    private readonly int _cooldown = 2;

    private Sword _sword;
    
    public Swordsman(IParameter healthParameter)
    {
        _sword = new Sword(_startAttack, _cooldown);
        _health = healthParameter;
        Sword = _sword;
    }

    public Sword Sword { get; private set; }
 
    public override int Health => _health.CurrentValue;

    public override void ApplyDamage(int damage) =>
        _health.ChangeValue(-damage);
}

public class PlayerHealth
{
    private readonly IParameter _parameter;

    public PlayerHealth(IParameter parameter) =>
        _parameter = parameter;

    public int Health => _parameter.CurrentValue;

    public void Heal(int healValue) =>
        _parameter.ChangeValue(healValue);

    public void ApplyDamage(int damage) =>
        _parameter.ChangeValue(-damage);
}

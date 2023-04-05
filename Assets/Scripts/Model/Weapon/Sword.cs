public class Sword : Weapon
{
    private int _damage;

    public Sword(int damage, int cooldown)
    {
        _damage = damage;
        Cooldown = cooldown;
    }

    public override int GetDamage() =>
        _damage;
}

public abstract class Weapon : IWeapon
{
    public int Cooldown { get; protected set; }

    public virtual int GetDamage() =>
        0;
}

using System;

public abstract class Bullet
{
    public static int MaxDamage => 100;

    public int Damage { get; protected set; }
    public int Cooldown { get; protected set; }
    public int LifeTime { get; protected set; }

    public void ChangeDamageValue(int newDamage)
    {
        if (newDamage >= 0)
            Damage = newDamage;
    }

    public void ChangeLifeTimeValue(int newValue)
    {
        if (newValue >= 0)
            LifeTime = newValue;
    }

    public void ChangeCooldownValue(int newValue)
    {
        if (newValue >= 0)
            Cooldown = newValue;
    }
}

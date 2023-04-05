public abstract class Enemy
{
    public virtual int Health { get; protected set; }

    public abstract void ApplyDamage(int damage);
}


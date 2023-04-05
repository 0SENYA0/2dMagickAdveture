public class FactoryBullet
{
    public IceBullet GetIceBullet() =>
        new IceBullet();

    public FireBullet GetFireBullet() =>
        new FireBullet();

    public IceBullet GetStartIceBullet()
    {
        IceBullet iceBullet = new IceBullet();
        iceBullet.ChangeCooldownValue(1);
        iceBullet.ChangeDamageValue(7);
        iceBullet.ChangeLifeTimeValue(3);

        return iceBullet;
    }

    public FireBullet GetStartFireBullet()
    {
        FireBullet fireBullet = new FireBullet();
        fireBullet.ChangeCooldownValue(1);
        fireBullet.ChangeDamageValue(5);
        fireBullet.ChangeLifeTimeValue(2);

        return fireBullet;
    }
}

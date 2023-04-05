using System;

public class Spell : Weapon
{
    private BulletDictionary _bulletDictionary;
    private Bullet _bullet;

    public int CurrentBulletLifeTime { get; private set; }
    public int CurrentBulletDamage { get; private set; }

    public Spell(BulletDictionary bulletDictionary)
    {
        _bulletDictionary = bulletDictionary;
    }

    public override int GetDamage() =>
        _bullet.Damage;

    public Bullet GetCurrentBullet() =>
        _bullet;

    public void SetBullet(Type typeBullet)
    {
        if (_bulletDictionary.GetBullet(typeBullet) is not null)
            _bullet = _bulletDictionary.GetBullet(typeBullet);
    }

    public void ChangeBulletLifeTime(int newValue)
    {
        CurrentBulletLifeTime = newValue;
        _bullet.ChangeLifeTimeValue(CurrentBulletLifeTime);
    }

    public void ChangeBulletDamage(int newValue) 
    {
        CurrentBulletDamage = newValue;
        _bullet.ChangeDamageValue(CurrentBulletDamage);
    }

    public void ChangeCooldownValue(int newValue)
    {
        Cooldown = newValue;
        _bullet.ChangeCooldownValue((int)Cooldown);
    }
}

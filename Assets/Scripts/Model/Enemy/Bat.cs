using UnityEngine;

public class Bat : Enemy
{
    private readonly IParameter _health;
    private Spell _spell;
    private FactoryBullet _factoryBullet;
    private BulletDictionary _bulletDictionary = new BulletDictionary();

    public Bat(IParameter healthParameter)
    {
        _factoryBullet = new FactoryBullet();
        SetStartBulletDictionary();
        _spell = new Spell(_bulletDictionary);
        FillSpell();
        _health = healthParameter;
        Spell = _spell;
    }

    public Spell Spell { get; private set; }

    public override int Health => _health.CurrentValue;

    public override void ApplyDamage(int damage) => 
        _health.ChangeValue(-damage);

    private Bullet GetRandomBullet()
    {
        int randomIndex = Random.Range(0, _bulletDictionary.Bullets.Count - 1);
        return _bulletDictionary.Bullets[randomIndex];
    }

    private void SetStartBulletDictionary()
    {
        FireBullet fireBullet = _factoryBullet.GetStartFireBullet();
        fireBullet.ChangeCooldownValue(2);
        IceBullet iceBullet= _factoryBullet.GetStartIceBullet();
        iceBullet.ChangeCooldownValue(2);

        _bulletDictionary.AddTypeBullet(fireBullet);
        _bulletDictionary.AddTypeBullet(iceBullet);
    }

    private void FillSpell()
    {
        var bullet = GetRandomBullet();
        _spell.SetBullet(bullet.GetType());
        _spell.ChangeBulletDamage(bullet.Damage);
        _spell.ChangeCooldownValue(bullet.Cooldown);
        _spell.ChangeBulletLifeTime(bullet.LifeTime);
    }
}

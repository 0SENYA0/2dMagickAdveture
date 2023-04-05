using System;

public class Player
{
    private PlayerHealth _health;
    private PlayerMana _mana;
    private Spell _spell;
    private BulletDictionary _bulletDictionary = new BulletDictionary();
    private FactoryBullet _factoryBullet;

    public Player(int startHealth, int startMana)
    {
        _factoryBullet = new FactoryBullet();
        FillStartBulletDictionary();
        _health = new PlayerHealth(new Parameter(startHealth));
        _mana = new PlayerMana(new Parameter(startMana));
        FireBullet startBullet = (FireBullet)_bulletDictionary.GetBullet(typeof(FireBullet));
        _spell = new Spell(_bulletDictionary);
        _spell.SetBullet(startBullet.GetType());
        Spell = _spell;
    }

    public Spell Spell { get; private set; }

    public int Health => _health.Health;

    public int Mana => _mana.Mana;

    public void UseMana(int value) =>
        _mana.Use(value);

    public void RechargeMana(int value) =>
        _mana.Recharge(value);

    public Bullet GetBullet(Type bulletType) =>
        _bulletDictionary.GetBullet(bulletType);

    public void ApplyDamage(int value) =>
        _health.ApplyDamage(value);

    public void Heal(int value) =>
            _health.Heal(value);

    public void AddTypeBullet(Bullet bullet) =>
        _bulletDictionary.AddTypeBullet(bullet);

    public void SetTypeBullet(Type bullet) =>
        _spell.SetBullet(bullet);

    public int GetDamage() =>
        _spell.GetDamage();

    public void ChangeBulletLifeTime(int newValue) =>
        _spell.ChangeBulletLifeTime(newValue);

    public void ChangeBulletDamage(int newValue) =>
        _spell.ChangeBulletDamage(newValue);

    public void ChangeCooldownValue(int newValue) =>
        _spell.ChangeCooldownValue(newValue);

    private void FillStartBulletDictionary()
    {
        _bulletDictionary.AddTypeBullet(_factoryBullet.GetStartFireBullet());
        _bulletDictionary.AddTypeBullet(_factoryBullet.GetStartIceBullet());
    }
}

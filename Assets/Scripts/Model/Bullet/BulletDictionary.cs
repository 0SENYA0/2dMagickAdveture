using System;
using System.Collections.Generic;
using System.Linq;

public class BulletDictionary
{
    public IReadOnlyList<Bullet> Bullets => _bullets.Values.ToList();
    private readonly Dictionary<Type, Bullet> _bullets = new Dictionary<Type, Bullet>();

    public void AddTypeBullet(Bullet bullet)
    {
        if (_bullets.ContainsKey(bullet.GetType()))
            return;

        _bullets.Add(bullet.GetType(), bullet);
    }

    public void RemoveTypeBullet(Bullet bullet)
    {
        if (_bullets.ContainsKey(bullet.GetType()) == false)
            return;

        _bullets.Remove(bullet.GetType(), out bullet);
    }

    public Bullet GetBullet(Type typeBullet)
    {
        if (_bullets.TryGetValue(typeBullet, out Bullet bullet))
            return bullet;

        return null;
    }
}

using System;
using UnityEngine;

public class EnemyWeaponPresenter : MonoBehaviour
{
    public event Action<int> Attacking;

    private Weapon _typeWeapon;
    
    public float Cooldown { get;private set; } = 2;

    public void SetTypeWeapon(Weapon weapon)
    {
        switch (weapon)
        {
            case Sword:
                _typeWeapon = weapon;
                break;
            case Spell:
                _typeWeapon = weapon;
                break;
        }

        Cooldown = weapon.Cooldown;
    }

    public void Attack() =>
        Attacking?.Invoke(_typeWeapon.GetDamage());
}

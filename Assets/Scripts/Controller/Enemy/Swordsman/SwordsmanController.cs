using System;
using UnityEngine;

public class SwordsmanController : EnemyController
{
    [SerializeField] private EnemyHealthController _enemyHealthController;
    [SerializeField] private EnemyWeaponController _enemyWeaponController;
    [SerializeField] private EnemyMoveController _enemyMoveController;
    [SerializeField] private SwordsmanAnimationView _swordsmanAnimationView;

    public event Action Dying;
    private Swordsman _swordsman;

    private void OnEnable()
    {
        _enemyWeaponController.Attacking += OnAttacking;
        _enemyHealthController.Damaged += OnDamaged;
    }

    private void OnDisable() 
    {
        _enemyWeaponController.Attacking -= OnAttacking;
        _enemyHealthController.Damaged -= OnDamaged;
    }

    private void Start()
    {
        IParameter health = new Parameter(_enemyHealthController.CurrentHealth);
        _swordsman = new Swordsman(health);
        _enemyHealthController.SetTypeEnemyHealth(_swordsman);
        _enemyWeaponController.SetTypeWeapon(_swordsman.Sword);
        _enemyMoveController.SetMoveStrategy(_swordsman);
    }

    public void Die()
    {
        _enemyHealthController.enabled = false;

        Dying?.Invoke();

        if (_swordsmanAnimationView.IsPlayDieAnimation() == false)
            DestroyEnemy();
    }

    private void OnDamaged(int damage)
    {
        if (_enemyHealthController.CurrentHealth <= 0)
            Die();
    }

    private void OnAttacking(int damage) =>
        AttackToPlayer(damage);    
}

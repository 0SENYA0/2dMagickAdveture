using System;
using UnityEngine;

public class SwordsmanPresenter : EnemyPresenter
{
    [SerializeField] private EnemyHealthPresenter _enemyHealthPresenter;
    [SerializeField] private EnemyWeaponPresenter _enemyWeaponPresenter;
    [SerializeField] private EnemyMovePresenter _enemyMovePresenter;
    [SerializeField] private SwordsmanAnimationView _swordsmanAnimationView;

    public event Action Dying;
    private Swordsman _swordsman;

    private void OnEnable()
    {
        _enemyWeaponPresenter.Attacking += OnAttacking;
        _enemyHealthPresenter.Damaged += OnDamaged;
    }

    private void OnDisable() 
    {
        _enemyWeaponPresenter.Attacking -= OnAttacking;
        _enemyHealthPresenter.Damaged -= OnDamaged;
    }

    private void Start()
    {
        IParameter health = new Parameter(_enemyHealthPresenter.CurrentHealth);
        _swordsman = new Swordsman(health);
        _enemyHealthPresenter.SetTypeEnemyHealth(_swordsman);
        _enemyWeaponPresenter.SetTypeWeapon(_swordsman.Sword);
        _enemyMovePresenter.SetMoveStrategy(_swordsman);
    }

    public void Die()
    {
        _enemyHealthPresenter.enabled = false;

        Dying?.Invoke();

        if (_swordsmanAnimationView.IsPlayDieAnimation() == false)
            DestroyEnemy();
    }

    private void OnDamaged(int damage)
    {
        if (_enemyHealthPresenter.CurrentHealth <= 0)
            Die();
    }

    private void OnAttacking(int damage) =>
        AttackToPlayer(damage);    
}

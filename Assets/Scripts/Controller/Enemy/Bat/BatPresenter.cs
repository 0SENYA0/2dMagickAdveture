using System;
using UnityEngine;

public class BatPresenter : EnemyPresenter
{
    [SerializeField] private EnemyHealthPresenter _enemyHealthPresenter;
    [SerializeField] private EnemyWeaponPresenter _enemyWeaponPresenter;
    [SerializeField] private EnemyMovePresenter _enemyMovePresenter;
    [SerializeField] private BatAnimationView _batAnimationView;

    public Bat Bat { get; private set; }
    public event Action Dying;
    private Bat _bat;
    
    private void Start()
    {
        IParameter parameter = new Parameter(_enemyHealthPresenter.CurrentHealth);
        _bat = new Bat(parameter);
        Bat = _bat;
        _enemyHealthPresenter.SetTypeEnemyHealth(_bat);
        _enemyWeaponPresenter.SetTypeWeapon(_bat.Spell);
        _enemyMovePresenter.SetMoveStrategy(_bat);
    }

    private void OnEnable()
    {
        _enemyHealthPresenter.Damaged += OnDamaged;
    }
    
    private void OnDisable()
    {
        _enemyHealthPresenter.Damaged -= OnDamaged;
    }

    public void Die()
    {
        _enemyHealthPresenter.enabled = false;

        Dying?.Invoke();

        if (_batAnimationView.IsPlayDieAnimation() == false)
            DestroyEnemy();
    }

    private void OnDying()
    {
        _enemyHealthPresenter.enabled = false;
        Destroy(gameObject);
    }

    private void OnDamaged(int damage)
    {
        if (_enemyHealthPresenter.CurrentHealth <= 0)
            Die();
    }
    
    
}

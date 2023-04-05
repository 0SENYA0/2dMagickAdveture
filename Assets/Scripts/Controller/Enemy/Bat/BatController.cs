using System;
using UnityEngine;

public class BatController : EnemyController
{
    [SerializeField] private EnemyHealthController _enemyHealthController;
    [SerializeField] private EnemyWeaponController _enemyWeaponController;
    [SerializeField] private EnemyMoveController _enemyMoveController;
    [SerializeField] private BatAnimationView _batAnimationView;

    public Bat Bat { get; private set; }
    public event Action Dying;
    private Bat _bat;
    
    private void Start()
    {
        IParameter parameter = new Parameter(_enemyHealthController.CurrentHealth);
        _bat = new Bat(parameter);
        Bat = _bat;
        _enemyHealthController.SetTypeEnemyHealth(_bat);
        _enemyWeaponController.SetTypeWeapon(_bat.Spell);
        _enemyMoveController.SetMoveStrategy(_bat);
    }

    private void OnEnable()
    {
        _enemyHealthController.Damaged += OnDamaged;
    }
    
    private void OnDisable()
    {
        _enemyHealthController.Damaged -= OnDamaged;
    }

    public void Die()
    {
        _enemyHealthController.enabled = false;

        Dying?.Invoke();

        if (_batAnimationView.IsPlayDieAnimation() == false)
            DestroyEnemy();
    }

    private void OnDying()
    {
        _enemyHealthController.enabled = false;
        Destroy(gameObject);
    }

    private void OnDamaged(int damage)
    {
        if (_enemyHealthController.CurrentHealth <= 0)
            Die();
    }
    
    
}

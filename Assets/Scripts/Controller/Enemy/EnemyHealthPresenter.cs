using System;
using UnityEngine;

public class EnemyHealthPresenter : HealthPresenter
{
    [Range(90, 100)]
    [SerializeField] private int _startHealth;
    
    public int CurrentHealth { get; private set; }
    public event Action<int> Damaged;
    
    private void Awake() =>
        CurrentHealth = _startHealth;

    private Enemy _typeEnemy;

    public void SetTypeEnemyHealth(Enemy enemy)
    {
        switch (enemy)
        {
            case Bat:
                _typeEnemy = enemy;
                break;
            case Swordsman:
                _typeEnemy = enemy;
                break;
            case EnemyHealer:
                _typeEnemy = enemy;
                break;
        }
    }

    private void Update()
    {}

    public override void ApplyDamage(int damage) 
    {
        _typeEnemy.ApplyDamage(damage);
        CurrentHealth = _typeEnemy.Health;
        Damaged?.Invoke(damage);
    }

    public override void Heal(int damage)
    {
    }
}

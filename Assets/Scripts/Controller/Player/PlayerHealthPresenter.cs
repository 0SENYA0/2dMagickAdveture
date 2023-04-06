using System;
using UnityEngine;

public class PlayerHealthPresenter : HealthPresenter
{
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private PlayerHealthView _playerHealthView;

    public int CurrentValue { get; private set; }
    
    private void Start() =>
        CurrentValue = _playerPresenter.Player.Health;

    public event Action<int> Damaged;

    public override void ApplyDamage(int damage)
    {
        Damaged?.Invoke(damage);
        _playerPresenter.Player.ApplyDamage(damage);
        CurrentValue = _playerPresenter.Player.Health;
        _playerHealthView.SetNewValue(_playerPresenter.Player.Health);
    }

    public override void Heal(int value)
    {
        _playerPresenter.Player.Heal(5);
        _playerHealthView.SetNewValue(_playerPresenter.Player.Health);
    }
}

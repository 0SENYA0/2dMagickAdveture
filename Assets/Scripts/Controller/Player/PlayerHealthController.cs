using System;
using UnityEngine;

public class PlayerHealthController : HealthController
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerHealthView _playerHealthView;

    public int CurrentValue { get; private set; }
    
    private void Start() =>
        CurrentValue = _playerController.Player.Health;

    public event Action<int> Damaged;

    public override void ApplyDamage(int damage)
    {
        Damaged?.Invoke(damage);
        _playerController.Player.ApplyDamage(damage);
        CurrentValue = _playerController.Player.Health;
        _playerHealthView.SetNewValue(_playerController.Player.Health);
    }

    public override void Heal(int value)
    {
        _playerController.Player.Heal(5);
        _playerHealthView.SetNewValue(_playerController.Player.Health);
    }
}

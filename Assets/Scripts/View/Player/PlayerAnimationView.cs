using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerControllerMovement _playerControllerMovement;
    [SerializeField] private PlayerWeaponController _playerWeaponController;

    private void OnEnable()
    {
        _playerControllerMovement.DirectionChanged += OnDirectionChanged;
        _playerWeaponController.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        _playerControllerMovement.DirectionChanged -= OnDirectionChanged;
        _playerWeaponController.Attacked -= OnAttacked;
    }

    private void OnAttacked() => 
        _animator.SetTrigger(PlayerAnimation.States.Attack);

    private void OnDirectionChanged(Vector2 direction) =>
        _animator.SetFloat(PlayerAnimation.Parameters.Speed, Mathf.Abs(direction.x));
}

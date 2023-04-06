using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovementPresenter _playerMovementPresenter;
    [SerializeField] private PlayerWeaponPresenter _playerWeaponPresenter;

    private void OnEnable()
    {
        _playerMovementPresenter.DirectionChanged += OnDirectionChanged;
        _playerWeaponPresenter.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        _playerMovementPresenter.DirectionChanged -= OnDirectionChanged;
        _playerWeaponPresenter.Attacked -= OnAttacked;
    }

    private void OnAttacked() => 
        _animator.SetTrigger(PlayerAnimation.States.Attack);

    private void OnDirectionChanged(Vector2 direction) =>
        _animator.SetFloat(PlayerAnimation.Parameters.Speed, Mathf.Abs(direction.x));
}

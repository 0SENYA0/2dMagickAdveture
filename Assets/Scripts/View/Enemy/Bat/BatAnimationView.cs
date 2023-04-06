using UnityEngine;

public class BatAnimationView : MonoBehaviour
{
    [SerializeField] private EnemyHealthPresenter _enemyHealthPresenter;
    [SerializeField] private EnemyWeaponPresenter _enemyWeaponPresenter;
    [SerializeField] private BatPresenter _batPresenter;
    [SerializeField] private EnemyMovePresenter _enemyMovePresenter;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _enemyWeaponPresenter.Attacking += OnAttacking;
        _batPresenter.Dying += OnDying;
        _enemyMovePresenter.Moving += OnMoving;
        _enemyHealthPresenter.Damaged += OnDamaged;
    }

    private void OnDisable()
    {
        _enemyMovePresenter.Moving -= OnMoving;
        _enemyHealthPresenter.Damaged -= OnDamaged;
        _batPresenter.Dying -= OnDying;
        _enemyWeaponPresenter.Attacking -= OnAttacking;
    }

    private void OnMoving(Vector2 direction) =>
        _animator.SetFloat(EnemyAnimation.Parameters.Speed, Mathf.Abs(direction.x));

    private void OnDying() =>
        _animator.SetBool(EnemyAnimation.Parameters.IsDead, true);

    public bool IsPlayDieAnimation() =>
        _animator.GetCurrentAnimatorStateInfo(0).IsName(EnemyAnimation.States.Death);

    private void OnAttacking(int damage) =>
        _animator.SetTrigger(EnemyAnimation.Parameters.Attack);

    private void OnDamaged(int damage) =>
        _animator.SetTrigger(EnemyAnimation.Parameters.Damage);
}


using UnityEngine;
public class SwordsmanAnimationView : MonoBehaviour
{
    [SerializeField] private EnemyHealthController _enemyHealthController;
    [SerializeField] private EnemyWeaponController _enemyWeaponController;
    [SerializeField] private SwordsmanController _swordsmanController;
    [SerializeField] private EnemyMoveController _enemyMoveController;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _enemyWeaponController.Attacking += OnAttacking;
        _swordsmanController.Dying += OnDying;
        _enemyMoveController.Moving += OnMoving;
        _enemyHealthController.Damaged += OnDamaged;
    }

    private void OnDisable()
    {
        _enemyMoveController.Moving -= OnMoving;
        _enemyHealthController.Damaged -= OnDamaged;
        _swordsmanController.Dying -= OnDying;
        _enemyWeaponController.Attacking -= OnAttacking;
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

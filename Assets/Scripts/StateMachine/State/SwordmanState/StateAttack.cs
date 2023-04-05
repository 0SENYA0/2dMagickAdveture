using System.Collections;
using UnityEngine;

public class StateAttack : State
{
    [SerializeField] private EnemyWeaponController _enemyWeaponController;

    private float _timer = 0f;
    private bool _canAttack = true;

    private Coroutine _coroutine;

    private void Update() =>
        ApplyAttack();

    public void ApplyAttack()
    {
        EnemyMoveController.Move(Vector2.zero);

        if (_canAttack == false)
            return;

        _enemyWeaponController.Attack();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(StartCooldown());
    }

    private IEnumerator StartCooldown()
    {
        while (_timer < _enemyWeaponController.Cooldown)
        {
            _canAttack = false;
            _timer += 1;
            yield return new WaitForSeconds(1);
        }

        _canAttack = true;
        _timer = 0f;
    }
}

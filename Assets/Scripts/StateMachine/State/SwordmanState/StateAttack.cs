using System.Collections;
using UnityEngine;

public class StateAttack : State
{
    [SerializeField] private EnemyWeaponPresenter _enemyWeaponPresenter;

    private float _timer = 0f;
    private bool _canAttack = true;

    private Coroutine _coroutine;

    private void Update() =>
        ApplyAttack();

    public void ApplyAttack()
    {
        EnemyMovePresenter.Move(Vector2.zero);

        if (_canAttack == false)
            return;

        _enemyWeaponPresenter.Attack();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(StartCooldown());
    }

    private IEnumerator StartCooldown()
    {
        WaitForSeconds timeToCooldown = new WaitForSeconds(1);
        
        while (_timer < _enemyWeaponPresenter.Cooldown)
        {
            _canAttack = false;
            _timer += 1;
            yield return timeToCooldown;
        }

        _canAttack = true;
        _timer = 0f;
    }
}

using System;
using System.Collections;
using UnityEngine;

public class PlayerWeaponPresenter : MonoBehaviour
{
    [SerializeField] private PlayerManaPresenter _playerManaPresenter;
    [SerializeField] private PlayerPresenter _playerPresenter;

    public event Action Attacked;

    private readonly int timeForRechargeMana = 3;
    private PlayerInput _inputActions;
    private Coroutine _manaRechargeCoroutine;
    private Coroutine _cooldownCoroutine;

    private int _weaponCooldown = 2;
    private bool _canAttack = true;

    private void Awake() =>
        _inputActions = new PlayerInput();

    private void Start() =>
        _weaponCooldown = (int)_playerPresenter.Player.Spell.Cooldown;

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Player.Shoot.started += ctx => OnAttack();
        _inputActions.Player.FireBullet.performed += ctx => SetFireBullet();
        _inputActions.Player.ColdBullet.performed += ctx => SetIceBullet();
    }

    private void OnDisable()
    {
        _inputActions.Player.Shoot.started -= ctx => OnAttack();
        _inputActions.Player.FireBullet.performed -= ctx => SetFireBullet();
        _inputActions.Player.ColdBullet.performed -= ctx => SetIceBullet();
        _inputActions.Disable();
    }

    private void OnAttack()
    {
        if (_canAttack == false)
            return;

        Attacked?.Invoke();

        if (_cooldownCoroutine != null)
            StopCoroutine(_cooldownCoroutine);

        _cooldownCoroutine = StartCoroutine(StartCooldownCoroutine());

        if (_manaRechargeCoroutine != null)
            StopCoroutine(_manaRechargeCoroutine);

        _manaRechargeCoroutine = StartCoroutine(StartTimerForReachargeManaCoroutine());
    }

    private void SetFireBullet() =>
        _playerPresenter.SetFireBullet();

    private void SetIceBullet() =>
        _playerPresenter.SetIceBullet();

    private IEnumerator StartTimerForReachargeManaCoroutine()
    {
        WaitForSeconds timeToRecharge = new WaitForSeconds(1);
        int timerRechargeMana = timeForRechargeMana;

        while (timerRechargeMana > 0)
        {
            timerRechargeMana--;
            yield return timeToRecharge;
        }

        _playerManaPresenter.Recharge();
    }

    private IEnumerator StartCooldownCoroutine()
    {
        WaitForSeconds timeToCooldown = new WaitForSeconds(1);
        int timerCooldown = _weaponCooldown;

        while (timerCooldown > 0)
        {
            _canAttack = false;
            timerCooldown--;
            yield return timeToCooldown;
        }

        _canAttack = true;
    }
}

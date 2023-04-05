using System;
using System.Collections;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerManaController _playerManaController;

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
        _weaponCooldown = (int)_playerController.Player.Spell.Cooldown;

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
        _playerController.SetFireBullet();

    private void SetIceBullet() =>
        _playerController.SetIceBullet();

    private IEnumerator StartTimerForReachargeManaCoroutine()
    {
        int timerRechargeMana = timeForRechargeMana;

        while (timerRechargeMana > 0)
        {
            timerRechargeMana--;
            yield return new WaitForSeconds(1);
        }

        _playerManaController.Recharge();
    }

    private IEnumerator StartCooldownCoroutine()
    {
        int timerCooldown = _weaponCooldown;

        while (timerCooldown > 0)
        {
            _canAttack = false;
            timerCooldown--;
            yield return new WaitForSeconds(1);
        }

        _canAttack = true;
    }
}

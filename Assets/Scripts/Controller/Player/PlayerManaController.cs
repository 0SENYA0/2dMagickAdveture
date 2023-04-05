using System.Collections;
using UnityEngine;

public class PlayerManaController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerManaView _playerManaView;

    public int CurrentValue => _playerController.Player.Mana;
    private Coroutine _coroutine;

    private readonly int _value = 5;

    public void Use(int value)
    {
        _playerController.Player.UseMana(_value);
        _playerManaView.SetNewValue(_playerController.Player.Mana);
    }

    public void Recharge()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(StartRechargeCoroutine());
    }

    private IEnumerator StartRechargeCoroutine()
    {
        while (_playerController.Player.Mana + _value <= _playerController.FullMana)
        {
            _playerController.Player.RechargeMana(_value);
            _playerManaView.SetNewValue(_playerController.Player.Mana);
            yield return new WaitForSeconds(1.5f);
        }
    }
}

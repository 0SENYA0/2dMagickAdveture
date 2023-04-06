using System.Collections;
using UnityEngine;

public class PlayerManaPresenter : MonoBehaviour
{
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private PlayerManaView _playerManaView;

    public int CurrentValue => _playerPresenter.Player.Mana;
    private Coroutine _coroutine;

    private readonly int _value = 5;

    public void Use(int value)
    {
        _playerPresenter.Player.UseMana(_value);
        _playerManaView.SetNewValue(_playerPresenter.Player.Mana);
    }

    public void Recharge()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(StartRechargeCoroutine());
    }

    private IEnumerator StartRechargeCoroutine()
    {
        WaitForSeconds secondToRecharge = new WaitForSeconds(1.5f);

        while (_playerPresenter.Player.Mana + _value <= _playerPresenter.FullMana)
        {
            _playerPresenter.Player.RechargeMana(_value);
            _playerManaView.SetNewValue(_playerPresenter.Player.Mana);
            yield return secondToRecharge;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBulletSpawnPresenter : MonoBehaviour
{
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private PlayerManaPresenter _playerManaPresenter;
    [SerializeField] private PlayerMovementPresenter _playerMovementPresenter;
    [SerializeField] private PlayerBulletView _playerBulletView;
    [SerializeField] private BulletComponent _bulletComponent;

    private readonly int useManaValue = 5;

    private Bullet _currentBullet;

    public Bullet CurrentBull => _currentBullet;

    public void SetBullet(Bullet typeBullet) =>
        _currentBullet = typeBullet;

    public void Atack()
    {
        if (_playerManaPresenter.CurrentValue >= useManaValue)
        {
            Vector3 direction = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            if (Vector3.Distance(direction, _playerPresenter.BackPoint.position) < Vector3.Distance(direction, _playerPresenter.ForwardPoint.position))
                _playerMovementPresenter.Flip();
            
            _playerManaPresenter.Use(useManaValue);
            _playerBulletView.SetTypeBulletView(_currentBullet);
            
            GameObject newBullet = Instantiate(_bulletComponent.gameObject, transform.position, Quaternion.identity);
            newBullet.GetComponent<BulletComponent>().Shoot(direction, _currentBullet, _playerBulletView.Speed);
            newBullet.GetComponent<SpriteRenderer>().sprite = _playerBulletView.Sprite;
        }
    }
}
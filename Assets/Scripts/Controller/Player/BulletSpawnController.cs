using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawnController : MonoBehaviour
{
    [SerializeField] private PlayerBulletView _playerBulletView;
    [SerializeField] private PlayerManaController _playerManaController;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerControllerMovement _playerControllerMovement;
    [SerializeField] private BulletGameObject _bulletGameObject;

    private readonly int useManaValue = 5;

    private Bullet _currentBullet;

    public Bullet CurrentBull => _currentBullet;

    public void SetBullet(Bullet typeBullet) =>
        _currentBullet = typeBullet;

    public void Atack()
    {
        if (_playerManaController.CurrentValue >= useManaValue)
        {
            Vector3 direction = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            if (Vector3.Distance(direction, _playerController.BackPoint.position) < Vector3.Distance(direction, _playerController.ForwardPoint.position))
                _playerControllerMovement.Flip();
            
            _playerManaController.Use(useManaValue);
            _playerBulletView.SetTypeBulletView(_currentBullet);
            
            GameObject newBullet = Instantiate(_bulletGameObject.gameObject, transform.position, Quaternion.identity);
            newBullet.GetComponent<BulletGameObject>().Shoot(direction, _currentBullet, _playerBulletView.Speed);
            newBullet.GetComponent<SpriteRenderer>().sprite = _playerBulletView.Sprite;
        }
    }
}
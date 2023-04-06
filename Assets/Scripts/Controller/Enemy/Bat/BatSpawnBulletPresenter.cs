using UnityEngine;

public class BatSpawnBulletPresenter : MonoBehaviour
{
    [SerializeField] private EnemyWeaponPresenter _enemyWeaponPresenter;
    [SerializeField] private BatPresenter _batController;
    [SerializeField] private BatBulletView _batBulletView;
    [SerializeField] private BulletComponent _bulletComponent;

    private void OnEnable() =>
        _enemyWeaponPresenter.Attacking += OnAttacking;

    private void OnDisable() =>
        _enemyWeaponPresenter.Attacking -= OnAttacking;

    public void InitBullet()
    {
        Vector3 direction = _batController.PlayerPosition;
        BulletComponent batBullet = Instantiate(_bulletComponent, transform.position, Quaternion.identity);
        batBullet.transform.position = transform.position;
        batBullet.GetComponent<SpriteRenderer>().sprite = _batBulletView.Sprite;
        batBullet.GetComponent<BulletComponent>().Shoot(direction, _batController.Bat.Spell.GetCurrentBullet(), _batBulletView.Speed);

        _batBulletView.SetTypeBulletView(_batController.Bat.Spell.GetCurrentBullet());
    }

    private void OnAttacking(int damage) =>
        InitBullet();
}

using UnityEngine;

public class BatSpawnBulletController : MonoBehaviour
{
    [SerializeField] private EnemyWeaponController _enemyWeaponController;
    [SerializeField] private BatController _batController;
    [SerializeField] private BatBulletView _batBulletView;
    [SerializeField] private BulletGameObject _bullet;

    private void OnEnable() =>
        _enemyWeaponController.Attacking += OnAttacking;

    private void OnDisable() =>
        _enemyWeaponController.Attacking -= OnAttacking;

    public void InitBullet()
    {
        Vector3 direction = _batController.GetPlayerPosition();
        BulletGameObject batBullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        batBullet.transform.position = transform.position;
        batBullet.GetComponent<SpriteRenderer>().sprite = _batBulletView.Sprite;
        batBullet.GetComponent<BulletGameObject>().Shoot(direction, _batController.Bat.Spell.GetCurrentBullet(), _batBulletView.Speed);

        _batBulletView.SetTypeBulletView(_batController.Bat.Spell.GetCurrentBullet());
    }

    private void OnAttacking(int damage) =>
        InitBullet();
}

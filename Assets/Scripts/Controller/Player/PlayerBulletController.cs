using System.Collections;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private Coroutine _coroutineFlyBullet;
    private Coroutine _coroutineTimer;

    private bool _needDestroy;

    private Bullet _bullet;

    private void Start()
    {
        _needDestroy = false;
        if (_coroutineTimer != null)
            StopCoroutine(_coroutineTimer);
        _coroutineTimer = StartCoroutine(StartCoroutineTimerToDestroy());
    }

    private IEnumerator StartCoroutineTimerToDestroy()
    {
        float timer = _bullet.LifeTime;

        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);
        }

        _needDestroy = true;
    }

    public void SetTypeBullet(Bullet bullet)
    {
        if (bullet != null)
            _bullet = bullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealthController enemyController))
            enemyController.ApplyDamage(_bullet.Damage);

        _needDestroy = true;
    }

    public void Shoot(Vector3 direction) =>
        _coroutineFlyBullet = StartCoroutine(FlyBullet(direction));

    private IEnumerator FlyBullet(Vector3 direction)
    {
        while (_needDestroy == false)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, direction, Time.deltaTime);
            yield return null;
        }

        DestroyBullet();
    }

    public void DestroyBullet()
    {
        if (_coroutineFlyBullet is not null)
            StopCoroutine(_coroutineFlyBullet);

        Destroy(gameObject);
    }
}

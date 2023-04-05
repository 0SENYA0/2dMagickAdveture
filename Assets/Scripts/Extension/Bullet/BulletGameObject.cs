using System.Collections;
using UnityEngine;

public class BulletGameObject : MonoBehaviour
{
    private Coroutine _coroutineFlyBullet;
    private Coroutine _coroutineTimer;

    private bool _needDestroy;

    private Bullet _bullet;
    private float _speed;
    private float _maxLifeTime = 4f;

    private void Start()
    {
        _needDestroy = false;
        if (_coroutineTimer != null)
            StopCoroutine(_coroutineTimer);
        _coroutineTimer = StartCoroutine(StartCoroutineTimerToDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthController healthController))
        {
            healthController.ApplyDamage(_bullet.Damage);
            _needDestroy = true;
        }
    }

    public void Shoot(Vector3 direction, Bullet bullet, float speed)
    {
        _coroutineFlyBullet = StartCoroutine(FlyBullet(direction));
        _bullet = bullet;
        _speed = speed;
    }

    private IEnumerator FlyBullet(Vector3 direction)
    {
        while (_needDestroy == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * _speed);

            if (transform.position == direction)
                _needDestroy = true;

            yield return null;
        }

        DestroyBullet();
    }

    private IEnumerator StartCoroutineTimerToDestroy()
    {
        float timer = _maxLifeTime;

        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);
        }

        _needDestroy = true;
    }

    private void DestroyBullet()
    {
        if (_coroutineFlyBullet is not null)
            StopCoroutine(_coroutineFlyBullet);

        Destroy(gameObject);
    }

}

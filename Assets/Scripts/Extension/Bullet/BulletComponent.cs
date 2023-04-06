using System.Collections;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    private Coroutine _coroutineFlyBullet;

    private bool _needDestroy;

    private Bullet _bullet;
    private float _speed;

    private void Start() =>
        _needDestroy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthPresenter healthController))
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
        Destroy(gameObject, _bullet.LifeTime);
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

    private void DestroyBullet()
    {
        if (_coroutineFlyBullet is not null)
            StopCoroutine(_coroutineFlyBullet);

        Destroy(gameObject);
    }
}


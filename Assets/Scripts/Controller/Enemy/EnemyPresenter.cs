using System;
using UnityEngine;

public class EnemyPresenter : MonoBehaviour
{
    protected PlayerHealthPresenter PlayerHealthPresenter { get; private set; }
    public event Action Destroing;

    public void InitPlayerHealth(PlayerHealthPresenter playerHealthController) =>
        PlayerHealthPresenter = playerHealthController;

    public Vector3 PlayerPosition => PlayerHealthPresenter.transform.position;

    public void DestroyEnemy()
    {
        Destroing?.Invoke();
        Destroy(gameObject);
    }

    public void AttackToPlayer(int damage) => 
        PlayerHealthPresenter.ApplyDamage(damage);
}

using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected PlayerHealthController PlayerHealthController { get; private set; }
    public event Action Destroing;

    public void InitPlayerHealth(PlayerHealthController playerHealthController) =>
        PlayerHealthController = playerHealthController;

    public Vector3 GetPlayerPosition() =>
        PlayerHealthController.transform.position;

    public void DestroyEnemy()
    {
        Destroing?.Invoke();
        Destroy(gameObject);
    }

    public void AttackToPlayer(int damage) => 
        PlayerHealthController.ApplyDamage(damage);
}

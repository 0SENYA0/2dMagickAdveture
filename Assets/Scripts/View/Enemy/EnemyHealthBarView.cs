using UnityEngine;

public class EnemyHealthBarView : MonoBehaviour
{
    [SerializeField] private EnemyHealthController _enemyHealthController;

    private void OnEnable() =>
        _enemyHealthController.Damaged += OnDamaged;

    private void OnDisable() =>
        _enemyHealthController.Damaged -= OnDamaged;

    private void OnDamaged(int damage)
    {
        float result = (float)_enemyHealthController.CurrentHealth / 1000 * 3;
        transform.localScale = new Vector3(result, transform.localScale.y);
    }
}
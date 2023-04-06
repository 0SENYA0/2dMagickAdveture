using UnityEngine;

public class EnemyHealthBarView : MonoBehaviour
{
    [SerializeField] private EnemyHealthPresenter _enemyHealthPresenter;

    private void OnEnable() =>
        _enemyHealthPresenter.Damaged += OnDamaged;

    private void OnDisable() =>
        _enemyHealthPresenter.Damaged -= OnDamaged;

    private void OnDamaged(int damage)
    {
        float result = (float)_enemyHealthPresenter.CurrentHealth / 1000 * 3;
        transform.localScale = new Vector3(result, transform.localScale.y);
    }
}
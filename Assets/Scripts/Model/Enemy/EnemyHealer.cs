using UnityEngine;

public class EnemyHealer : Enemy
{
    private readonly float _distanceToHeal = 4f;
    private IParameter _health;

    public EnemyHealer(IParameter health)
    {
        _health = health;
    }

    public int Heal()
    {
        return 2;
    }

    public bool TryGetTargetToHeal(Vector3 healerPosition, Vector3 targetPosition)
    {
        float distanceToTarget = Vector3.Distance(healerPosition, targetPosition);

        if (distanceToTarget <= _distanceToHeal)
        {
            Heal();
            return true;
        }

        return false;
    }

    public int GetRandomDirection() =>
        Random.Range(-1, 1);

    public override void ApplyDamage(int damage) =>
        _health.ChangeValue(-damage);
}

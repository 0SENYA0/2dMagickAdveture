using UnityEngine;

public class TransitionToAttack : Transition
{
    [SerializeField] private float _distance;
    
    private void Update()
    {
        if (IsPositionToAttack(transform.position, EnemyMovePresenter.GetPlayerPosition()))
            NeedTransit = true;
        
        return;
    }

    public bool IsPositionToAttack(Vector3 atackerPosition, Vector3 targetPosition)
    {
        float distanceToTarget = Vector3.Distance(atackerPosition, targetPosition);

        if (distanceToTarget <= _distance)
            return true;

        return false;
    }
}

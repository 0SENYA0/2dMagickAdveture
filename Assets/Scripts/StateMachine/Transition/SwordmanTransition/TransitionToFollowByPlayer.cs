using UnityEngine;

public class TransitionToFollowByPlayer : Transition
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minDistance;
    
    private void Update()
    {
        if (Vector2.Distance(transform.position, EnemyMoveController.GetPlayerPosition()) < _maxDistance && 
            Vector2.Distance(transform.position, EnemyMoveController.GetPlayerPosition()) > _minDistance)
                NeedTransit = true;
    }
}

using UnityEngine;

public class TransitionToPatrol : Transition
{
    [SerializeField] float _distanceLose;
    
    private void Update()
    {
        if (Vector3.Distance(transform.position, EnemyMovePresenter.GetPlayerPosition()) > _distanceLose)
            NeedTransit = true;
    }
}

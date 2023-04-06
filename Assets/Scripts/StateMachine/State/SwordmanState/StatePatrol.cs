using UnityEngine;

public class StatePatrol : State
{
    private void Update()
    {
        EnemyMovePresenter.Move(Vector2.zero);
    }
}

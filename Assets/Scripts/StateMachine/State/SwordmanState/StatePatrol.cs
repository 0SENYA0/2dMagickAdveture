using UnityEngine;

public class StatePatrol : State
{
    private void Update()
    {
        EnemyMoveController.Move(Vector2.zero);
    }
}

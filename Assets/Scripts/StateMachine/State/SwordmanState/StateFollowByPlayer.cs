using UnityEngine;

public class StateFollowByPlayer : State
{
    private void FixedUpdate() =>
        CheckPlayerPosition();

    private void CheckPlayerPosition()
    {
        if (EnemyMoveController.GetPlayerPosition().x > transform.position.x)
            EnemyMoveController.Move(Vector2.right);
        else if(EnemyMoveController.GetPlayerPosition().x < transform.position.x)
            EnemyMoveController.Move(Vector2.left);
    }
}

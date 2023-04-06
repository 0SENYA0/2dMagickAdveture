using UnityEngine;

public class StateFollowByPlayer : State
{
    private void FixedUpdate() =>
        CheckPlayerPosition();

    private void CheckPlayerPosition()
    {
        if (EnemyMovePresenter.GetPlayerPosition().x > transform.position.x)
            EnemyMovePresenter.Move(Vector2.right);
        else if(EnemyMovePresenter.GetPlayerPosition().x < transform.position.x)
            EnemyMovePresenter.Move(Vector2.left);
    }
}

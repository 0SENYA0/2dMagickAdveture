using UnityEngine;

public class MovementStrategy : MonoBehaviour
{
    private IMovement _movement;

    public void Set(IMovement movement) =>
        _movement = movement;

    public void Move(Vector2 direction, float speed) =>
        _movement.Move(direction, speed);
}

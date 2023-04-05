using UnityEngine;

public class FlyMoveStrategy : IMovement
{
    private readonly Rigidbody2D _rigidbody2D;


    public FlyMoveStrategy(Rigidbody2D rigidbody2D) =>
        _rigidbody2D = rigidbody2D;

    public void Move(Vector2 direction, float speed)
    {
        Vector2 offset = direction.normalized * speed * Time.deltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + offset);
    }
}

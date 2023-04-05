using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
public class RunMoveStrategy 
{
    private Vector2 _normal;
    public float Speed { get; private set; }
    public PhysicsMovement _physicsMovement;

    public RunMoveStrategy(float speed) 
    {
        Speed = speed;
    }
    
    public void Move(Vector2 direction, Rigidbody2D rigidbody2D)
    {
        //Vector2 directionAlongSurface = Project(direction.normalized);
        //Vector2 offset = directionAlongSurface * (Speed * Time.deltaTime);
        //rigidbody2D.MovePosition(rigidbody2D.position + offset);
    }
}

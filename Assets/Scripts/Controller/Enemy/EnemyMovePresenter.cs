using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyPresenter))]
[RequireComponent(typeof(MovementStrategy))]
[RequireComponent(typeof(PhysicsMovement))]
public class EnemyMovePresenter : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action<Vector2> Moving;
    private bool _isRightDirection = false;
    private Rigidbody2D _rigidbody2D;
    private EnemyPresenter _enemyController;
    private MovementStrategy _movementStrategy;
    private PhysicsMovement _physicsMovement;
    private Vector2 _direction;

    private void Awake()
    {
        _direction = Vector2.zero;
        _physicsMovement = GetComponent<PhysicsMovement>();
    }

    private void Start()
    {
        _movementStrategy = GetComponent<MovementStrategy>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyController = GetComponent<EnemyPresenter>();
    }

    private void FixedUpdate() =>
        _movementStrategy.Move(_direction, _speed);

    public void SetMoveStrategy(Enemy enemy)
    {
        switch (enemy)
        {
            case Swordsman:
                _movementStrategy.Set(_physicsMovement);
                _physicsMovement.enabled = true;
                break;
            case Bat:
                _movementStrategy.Set((new FlyMoveStrategy(_rigidbody2D)));
                break;
        }
    }

    public void Move(Vector2 direction)
    {
        _direction = direction;
        Moving?.Invoke(direction);

        if (direction.x > 0 && !_isRightDirection)
            Flip();
        else if (direction.x < 0 && _isRightDirection)
            Flip();
    }

    public Vector3 GetPlayerPosition() =>
       _enemyController.PlayerPosition;

    public void Flip()
    {
        _isRightDirection = !_isRightDirection;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

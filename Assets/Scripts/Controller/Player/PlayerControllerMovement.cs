using System;
using UnityEngine;

public class PlayerControllerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PhysicsMovement _physicsMovement;

    public event Action<Vector2> DirectionChanged;
    private PlayerInput _inputActions;
    private Vector2 _direction;
    private bool _isRightDirection = true;

    private void Awake() =>
        _inputActions = new PlayerInput();

    void FixedUpdate() =>
        _physicsMovement.Move(_direction, _speed);

    void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Player.Move.performed += ctx => OnMoveStart(ctx.ReadValue<Vector2>());
        _inputActions.Player.Move.canceled += ctx => OnMoveEnd();
    }

    private void OnDisable()
    {
        _inputActions.Player.Move.performed -= ctx => OnMoveStart(ctx.ReadValue<Vector2>());
        _inputActions.Player.Move.canceled -= ctx => OnMoveEnd();
        _inputActions.Disable();
    }

    public void Flip()
    {
        _isRightDirection = !_isRightDirection;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void OnMoveStart(Vector2 direction)
    {
        if (direction.x > 0 && !_isRightDirection)
            Flip();
        else if (direction.x < 0 && _isRightDirection)
            Flip();

        _direction = direction;
        DirectionChanged?.Invoke(_direction);
    }

    private void OnMoveEnd()
    {
        _direction = Vector2.zero;
        DirectionChanged?.Invoke(_direction);
    }
}

















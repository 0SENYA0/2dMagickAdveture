using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsMovement : MonoBehaviour, IMovement
{
    [SerializeField] private LayerMask LayerMask;

    private const float MinMoveDistance = 0.001f;
    private const float ShellRadius = 0.01f;
    private const float MinGroundNormalY = .65f;
    private const float GravityModifier = 1f;

    private bool _isGrounded;
    private Vector2 _velocity;
    private Vector2 _groundNormal;
    private Rigidbody2D _rigidbody2D;
    private ContactFilter2D _contactFilter;
    private RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> _hitBufferList = new List<RaycastHit2D>(16);

    void Awake() =>
        _rigidbody2D = GetComponent<Rigidbody2D>();

    void Start()
    {
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(LayerMask);
        _contactFilter.useLayerMask = true;
    }

    public void Move(Vector2 direction, float speed)
    {
        _velocity += GravityModifier * Physics2D.gravity * Time.deltaTime;
        _velocity.x = direction.x;

        _isGrounded = false;

        Vector2 deltaPosition = _velocity * Time.deltaTime * speed;
        Vector2 moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    private void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > MinMoveDistance)
        {
            int count = _rigidbody2D.Cast(move, _contactFilter, _hitBuffer, distance + ShellRadius);

            _hitBufferList.Clear();

            for (int i = 0; i < count; i++)
                _hitBufferList.Add(_hitBuffer[i]);

            for (int i = 0; i < _hitBufferList.Count; i++)
            {
                Vector2 currentNormal = _hitBufferList[i].normal;

                if (currentNormal.y > MinGroundNormalY)
                {
                    _isGrounded = true;
                    
                    if (yMovement)
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(_velocity, currentNormal);
                
                if (projection < 0)
                    _velocity = _velocity - projection * currentNormal;

                float modifiedDistance = _hitBufferList[i].distance - ShellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        _rigidbody2D.position = _rigidbody2D.position + move.normalized * distance;
    }
}
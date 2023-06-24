using UnityEngine;

[RequireComponent(typeof(CreatureMovement))]

public class EnemyMoveState : EnemyState
{
    [SerializeField] private float _speed;

    private readonly int _velocityKey = Animator.StringToHash("Velocity");

    private CreatureMovement _movement;
    private Vector2 _direction;
    private float _stopSpeed = 0f;

    private void Awake()
    {
        _movement = GetComponent<CreatureMovement>();
    }

    private void Update()
    {
        SetDirection();
        float speed = _ball.Owner == Ball.BallOwner.Player ? _stopSpeed : _speed;
        Animator?.SetFloat(_velocityKey, speed);
        _movement.Move(_direction, speed);
    }

    private void OnDisable()
    {
        Animator?.SetFloat(_velocityKey, 0);
    }

    private void SetDirection()
    {
        Vector2 heading = new Vector2(_ball.transform.position.x - transform.position.x, _ball.transform.position.z - transform.position.z);
        float distance = heading.magnitude;
        _direction = heading / distance;
    }
}

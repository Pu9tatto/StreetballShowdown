using UnityEngine;

[RequireComponent(typeof(CreatureMovement))]

public class EnemyMoveState : EnemyState
{
    [SerializeField] private float _speed;

    private readonly int _velocityKey = Animator.StringToHash("Velocity");

    private CreatureMovement _movement;
    private Vector2 _direction;

    private void Awake()
    {
        _movement = GetComponent<CreatureMovement>();
    }

    private void Update()
    {
        SetDirection();
        _movement.Move(_direction, _speed);
    }

    private void SetDirection()
    {
        Vector2 heading = new Vector2(_ball.transform.position.x - transform.position.x, _ball.transform.position.z - transform.position.z);
        float distance = heading.magnitude;
        _direction = heading / distance;

        Animator?.SetFloat(_velocityKey, _direction.sqrMagnitude);
    }
}

using UnityEngine;

[RequireComponent(typeof(CreatureMovement))]

public class EnemyDribbleState : EnemyState
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isRunAway;

    private readonly int _velocityKey = Animator.StringToHash("Velocity");
    private readonly int _isDribbleKey = Animator.StringToHash("IsDribble");

    private CreatureMovement _movement;
    private Vector2 _direction;

    private void Awake()
    {
        _movement = GetComponent<CreatureMovement>();
    }

    private void OnEnable()
    {
        Animator?.SetBool(_isDribbleKey, true);
    }

    private void Update()
    {
        SetDirection();
        _movement.Move(_direction, _speed);
    }

    private void SetDirection()
    {
        Vector2 heading = new Vector2(_goalPoint.transform.position.x - transform.position.x, _goalPoint.transform.position.z - transform.position.z);
        float distance = heading.magnitude;
        _direction = heading / distance;

        Animator?.SetFloat(_velocityKey, _direction.sqrMagnitude);

        if (_isRunAway)
        {
            _direction.x *= -1;
            _direction.y *= _direction.y < 0 ? 1 : -1;
        }
    }
}

using UnityEngine;

public class EnemyDribbleState : EnemyState
{
    [SerializeField] private float _speed;

    private readonly int _velocityKey = Animator.StringToHash("Velocity");
    private readonly int _isDribbleKey = Animator.StringToHash("IsDribble");

    private Rigidbody _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Animator?.SetBool(_isDribbleKey, true);
        _rigidbody.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        SetDirection();
        TryRotate();
        Move();
    }

    private void SetDirection()
    {
        Vector2 heading = new Vector2(_goalPoint.transform.position.x - transform.position.x, _goalPoint.transform.position.z - transform.position.z);
        float distance = heading.magnitude;
        _direction = heading / distance;

        Animator?.SetFloat(_velocityKey, _direction.sqrMagnitude);
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_direction.x * _speed, 0, _direction.y * _speed);
    }

    private void TryRotate()
    {
        if (_direction.x != 0 || _direction.y != 0)
        {
            Vector3 rotateDirection = new Vector3(_direction.x, 0, _direction.y);

            if (rotateDirection != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(rotateDirection);
        }
    }

}

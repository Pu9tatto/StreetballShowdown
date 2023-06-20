using UnityEngine;

public class DribbleState : State
{
    [SerializeField] private float _speed;

    private readonly int _velocityKey = Animator.StringToHash("Velocity");
    private readonly int _isDribbleKey = Animator.StringToHash("IsDribble");

    private IControllable _controller;
    private Rigidbody _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _controller = GetComponent<IControllable>();
    }

    private void OnEnable()
    {
        Animator?.SetBool(_isDribbleKey, true);
    }

    private void FixedUpdate()
    {
        SetDirection();
        TryRotate();
        Move();
    }

    private void SetDirection()
    {
        _direction = _controller.GetDirection();

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
            Vector3 rotateDirection = _rigidbody.velocity;
            rotateDirection.y = 0;

            if (rotateDirection.x != 0)
                transform.rotation = Quaternion.LookRotation(rotateDirection);
        }
    }
}

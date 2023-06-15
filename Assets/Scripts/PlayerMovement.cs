using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private IControllable _controller;
    private Rigidbody _rigidbody;
    private Vector2 _direction;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _controller = GetComponent<IControllable>();
    }

    private void FixedUpdate()
    {
        SetDirection();
        Move();
        TryRotate();
    }

    private void SetDirection()
    {
        _direction = _controller.GetDirection();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_direction.x * _speed, _rigidbody.velocity.y, _direction.y* _speed);
    }

    private void TryRotate()
    {
        if (_direction.x != 0 || _direction.y != 0)
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
    }
}
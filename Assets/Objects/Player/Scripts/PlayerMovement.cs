using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;

    public event UnityAction<Vector3> MovementChanged;
    public event UnityAction<bool> DribbleChanged;
    public event UnityAction Jumped;

    private IControllable _controller;
    private Rigidbody _rigidbody;
    private Vector2 _direction;
    private bool _isJumping;
    private bool _isDribble;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _controller = GetComponent<IControllable>();
    }

    private void FixedUpdate()
    {
        if (_isJumping == false)
        {
            SetDirection();
            TryRotate();
            Move();
        }
    }

    public void PickBall()
    {
        _isDribble = true;
        DribbleChanged?.Invoke(true);
    }

    public void ThrowBall()
    {
        _isDribble = false;
        DribbleChanged?.Invoke(false);
    }

    public void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping && _isDribble)
        {
            Vector3 startPosition = transform.position;

            Jumped?.Invoke();

            StartCoroutine(JumpRoutine(startPosition));
        }
    }

    private IEnumerator JumpRoutine(Vector3 startPosition)
    {
        _isJumping = true;
        _direction = Vector3.zero;

        MovementChanged?.Invoke(_direction);

        float timer = 0f;

        while (timer < _jumpDuration)
        {
            float jumpProgress = timer / _jumpDuration;
            float yOffset = Mathf.Sin(jumpProgress * Mathf.PI) * _jumpHeight;

            transform.position = startPosition +  new Vector3(0f, yOffset, 0f);

            timer += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;

        _isJumping = false;
    }

    private void SetDirection()
    {
        _direction = _controller.GetDirection();
        MovementChanged?.Invoke(_direction);
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_direction.x * _speed, _rigidbody.velocity.y, _direction.y* _speed);
    }

    private void TryRotate()
    {
        if (_direction.x != 0 || _direction.y != 0)
        {
            Vector3 rotateDirection = _rigidbody.velocity;
            rotateDirection.y = 0;

            if(rotateDirection.x != 0)
                transform.rotation = Quaternion.LookRotation(rotateDirection);
        }
    }
}
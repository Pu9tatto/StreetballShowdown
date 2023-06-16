using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

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
        DribbleChanged?.Invoke(true);
    }

    public void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
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
        DribbleChanged?.Invoke(false);

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

            transform.rotation = Quaternion.LookRotation(rotateDirection);
        }
    }
}
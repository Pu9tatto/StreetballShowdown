using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]

public class PlayerAnimation : MonoBehaviour
{
    private readonly int _velocityKey = Animator.StringToHash("Velocity");
    private readonly int _isDribbleKey = Animator.StringToHash("IsDribble");
    private readonly int _shootKey = Animator.StringToHash("Shoot");
    private readonly int _pickBallKey = Animator.StringToHash("PickBall");


    private Animator _animator;
    private Vector2 _direction;
    private bool _isDribble = false;
    private PlayerMovement _movement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _movement.DribbleChanged += OnDribbleChanged;
        _movement.MovementChanged += OnMove;
        _movement.Jumped += OnJump;
    }


    private void OnDisable()
    {
        _movement.DribbleChanged -= OnDribbleChanged;
        _movement.MovementChanged -= OnMove;
        _movement.Jumped -= OnJump;
    }

    private void Update()
    {
        _animator.SetFloat(_velocityKey, _direction.sqrMagnitude);
    }

    public void SetDribble(bool isDribble) => _isDribble = isDribble;

    private void OnDribbleChanged(bool isDribble)
    {
        _animator.SetBool(_isDribbleKey, isDribble);
    }

    private void OnMove(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnJump()
    {
        _animator.SetTrigger(_shootKey);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Ball>(out Ball ball))
        {
            _isDribble = true;
        }
    }
}

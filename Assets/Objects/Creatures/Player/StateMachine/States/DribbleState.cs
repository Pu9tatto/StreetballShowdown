using UnityEngine;

[RequireComponent(typeof(CreatureMovement))]
public class DribbleState : State
{
    [SerializeField] private float _speed;

    private readonly int _velocityKey = Animator.StringToHash("Velocity");
    private readonly int _isDribbleKey = Animator.StringToHash("IsDribble");

    private IControllable _controller;
    private CreatureMovement _movement;
    private Vector2 _direction;

    private void Awake()
    {
        _movement = GetComponent<CreatureMovement>();
        _controller = GetComponent<IControllable>();
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
        _direction = _controller.GetDirection();

        Animator?.SetFloat(_velocityKey, _direction.sqrMagnitude);
    }
}

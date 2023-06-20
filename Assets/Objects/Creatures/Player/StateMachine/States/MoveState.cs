using UnityEngine;

[RequireComponent(typeof(CreatureMovement))]
public class MoveState : State
{
    [SerializeField] private float _speed;

    private readonly int _velocityKey = Animator.StringToHash("Velocity");

    private IControllable _controller;
    private CreatureMovement _movement;
    private Vector2 _direction;

    private void Awake()
    {
        _movement = GetComponent<CreatureMovement>();
        _controller = GetComponent<IControllable>();
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

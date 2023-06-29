using UnityEngine;

[RequireComponent(typeof(CreatureMovement))]
public class MoveState : State
{
    private IControllable _controller;
    private CreatureMovement _movement;
    private Vector2 _direction;
    private float _speed;

    private void Awake()
    {
        _movement = GetComponent<CreatureMovement>();
        _controller = GetComponent<IControllable>();
        _speed = GetComponent<PlayerCharacteristics>().GetSpeed();
    }

    private void OnEnable()
    {
        Animator.SetBool(Constants.IsDribbleKey, false);
    }

    private void Update()
    {
        SetDirection();
        _movement.Move(_direction, _speed);
    }

    private void SetDirection()
    {
        _direction = _controller.GetDirection();

        Animator?.SetFloat(Constants.VelocityKey, _direction.sqrMagnitude);
    }
}

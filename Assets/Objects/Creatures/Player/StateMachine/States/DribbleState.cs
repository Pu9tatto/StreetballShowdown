using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CreatureMovement))]
public class DribbleState : State
{
    [SerializeField] private BasketPoint _goalPoint;

    public event UnityAction<bool> OutOffThreePoint;

    private IControllable _controller;
    private CreatureMovement _movement;
    private Vector2 _direction;
    private float _speed;

    private void Awake()
    {
        _movement = GetComponent<CreatureMovement>();
        _controller = GetComponent<IControllable>();
        _speed = GetComponent<PlayerCharacteristics>().GetSpeed() * Constants.DribbleModifySpeed;
    }

    private void OnEnable()
    {
        Animator?.SetBool(Constants.IsDribbleKey, true);
    }

    private void Update()
    {
        CheckOutOffThreePoint();
        SetDirection();
        _movement.Move(_direction, _speed);
    }

    private void SetDirection()
    {
        _direction = _controller.GetDirection().normalized;

        Animator?.SetFloat(Constants.VelocityKey, _direction.sqrMagnitude);
    }

    private void CheckOutOffThreePoint()
    {
        Vector2 heading = new Vector2(_goalPoint.transform.position.x - transform.position.x, _goalPoint.transform.position.z - transform.position.z);
        float sqrDistance = heading.sqrMagnitude;

        if (sqrDistance > Constants.ThreePointDistance * Constants.ThreePointDistance)
            OutOffThreePoint?.Invoke(true);
    }
}

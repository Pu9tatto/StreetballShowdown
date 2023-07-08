using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CreatureMovement))]

public class EnemyDribbleState : EnemyState
{
    [SerializeField] private bool _isRunAway;

    public event UnityAction<bool> OutOffThreePoint;

    private CreatureMovement _movement;
    private Vector2 _direction;
    private float _speed;

    private void Awake()
    {
        _movement = GetComponent<CreatureMovement>();
    }

    private void OnEnable()
    {
        Animator?.SetBool(Constants.IsDribbleKey, true);
        _speed = GetComponent<EnemyCharacteristics>().GetSpeed();
    }

    private void OnDisable()
    {
        Animator?.SetFloat(Constants.VelocityKey, 0);
    }

    private void Update()
    {
        SetDirection();
        _movement.Move(_direction, _speed);
    }

    private void SetDirection()
    {
        Vector2 heading = new Vector2(_goalPoint.transform.position.x - transform.position.x, _goalPoint.transform.position.z - transform.position.z);
        float distance = heading.magnitude;
        _direction = heading / distance;

        CheckOutOffThreePoint(distance);

        Animator?.SetFloat(Constants.VelocityKey, _direction.sqrMagnitude);

        if (_isRunAway)
        {
            _direction.x *= -1;
            _direction.y *= _direction.y < 0 ? 1 : -1;
        }
    }

    private void CheckOutOffThreePoint(float distance)
    {
        if (distance* distance > Constants.ThreePointDistance * Constants.ThreePointDistance)
            OutOffThreePoint?.Invoke(false);
    }
}

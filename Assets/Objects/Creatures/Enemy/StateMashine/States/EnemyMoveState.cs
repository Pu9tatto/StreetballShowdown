using UnityEngine;

[RequireComponent(typeof(CreatureMovement))]
public class EnemyMoveState : EnemyState
{
    [SerializeField] protected float _speed;

    protected Vector2 Direction;

    private CreatureMovement _movement;
    private float _stopSpeed = 0f;

    private void Awake()
    {
        _movement = GetComponent<CreatureMovement>();
    }

    private void Update()
    {
        SetDirection();
        float speed = _ball.Owner == Ball.BallOwner.Player ? _stopSpeed : _speed;
        Animator?.SetFloat(Constants.VelocityKey, speed);
        _movement.Move(Direction, speed);
    }

    private void OnEnable()
    {
        Animator?.SetBool(Constants.IsDribbleKey, false);
    }

    private void OnDisable()
    {
        Animator?.SetFloat(Constants.VelocityKey, 0);
    }

    protected virtual void SetDirection()
    {
        Vector2 heading = new Vector2(_ball.transform.position.x - transform.position.x, _ball.transform.position.z - transform.position.z);
        float distance = heading.magnitude;
        Direction = heading / distance;
    }
}

using UnityEngine;

public class MoveToDefenceState : EnemyMoveState
{
    [SerializeField] private Transform _target;

    protected override void SetDirection()
    {
        Vector2 heading = new Vector2(_target.transform.position.x - transform.position.x, _target.transform.position.z - transform.position.z);
        float distance = heading.magnitude;
        Direction = heading / distance;
    }
}
using UnityEngine;
using UnityEngine.Events;

public class BallThrower : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] protected BasketPoint GoalPoint;
    [SerializeField] protected BasketPoint[] OverpowerMissPoints;
    [SerializeField] protected BasketPoint[] UnderpowerMissPoints;
    [Space]
    [Header("Throw Settings")]
    [SerializeField] private float _throwHewight;
    [SerializeField] private float _throwSpeed;

    public event UnityAction<bool> IsPickedBall;
    protected Ball Ball;
    protected float Distance;

    private BasketPoint _aimPoint;

    public float GetThrowDistance() => Distance;

    public void SetBall(Ball ball) 
    {
        Ball = ball;
        IsPickedBall?.Invoke(true);
    }

    public void LoseBall()
    {
        if(Ball == null) return;

        Ball.transform.parent = null;
        Ball.StartThrow(Ball.transform.position+Vector3.right, 0, 2, 0);

        Ball = null;
        IsPickedBall?.Invoke(false);
    }

    public void LookAtGoal()
    {
        Vector3 rotateDirection = GoalPoint.transform.position - transform.position;
        rotateDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(rotateDirection);
    }

    public void Throw()
    {
        if (Ball != null)
        {
            Ball.transform.parent = null;

            _aimPoint = CalculateThrowPoint();

            Ball.StartThrow(_aimPoint.transform.position, _throwHewight, _throwSpeed, Distance);

            Ball = null;

            IsPickedBall?.Invoke(false);
        }
    }

    protected virtual BasketPoint CalculateThrowPoint()
    {
        return null;
    }

    protected virtual void CalculateDistance()
    {
        Vector2 planeTargetPosition = new Vector2(GoalPoint.transform.position.x, GoalPoint.transform.position.z);
        Vector2 planeEnemyPosition = new Vector2(transform.position.x, transform.position.z);

        Vector2 throwDirection = planeTargetPosition - planeEnemyPosition;

        Distance = throwDirection.magnitude;
    }

}

using UnityEngine;

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

    protected Ball Ball;
    private BasketPoint _aimPoint;

    public void SetBall(Ball ball) => Ball = ball;

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

            Ball.StartThrow(_aimPoint, _throwHewight, _throwSpeed);

            Ball = null;
        }
    }

    protected virtual BasketPoint CalculateThrowPoint()
    {
        return null;
    }
}

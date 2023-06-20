using UnityEngine;

public class EnemyBallThrower : BallThrower
{
    [SerializeField, Range(0, 1)] private float _minRateForGoal;
    [SerializeField, Range(0, 1)] private float _maxRateForGoal;

    protected override BasketPoint CalculateThrowPoint()
    {
        float rate = Random.value;

        if (rate > _maxRateForGoal)
            return OverpowerMissPoints[Random.Range(0, OverpowerMissPoints.Length)];
        else if (rate < _minRateForGoal)
            return UnderpowerMissPoints[Random.Range(0, UnderpowerMissPoints.Length)];
        else
            return GoalPoint;
    }
}

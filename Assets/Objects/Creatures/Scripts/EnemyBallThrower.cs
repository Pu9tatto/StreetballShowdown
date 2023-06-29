using UnityEngine;

public class EnemyBallThrower : BallThrower
{
    private float _middlePower = 0.5f;
    private float _accuracy = 0f;
    private float _modifyAccuracy = 0.001f;
    private void Awake()
    {
        _accuracy = GetComponent<EnemyCharacteristics>().GetAccuracy();
    }

    protected override BasketPoint CalculateThrowPoint()
    {
        float rate = Random.value;

        CalculateDistance();

        if (rate > _middlePower + _accuracy* _modifyAccuracy)
            return OverpowerMissPoints[Random.Range(0, OverpowerMissPoints.Length)];
        else if (rate < _middlePower - _accuracy* _modifyAccuracy)
            return UnderpowerMissPoints[Random.Range(0, UnderpowerMissPoints.Length)];
        else
            return GoalPoint;

    }
}

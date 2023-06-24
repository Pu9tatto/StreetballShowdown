using UnityEngine;

public class PlayerBallThrower : BallThrower
{
    [Header("Points")]
    [SerializeField] private BasketPoint[] _missPoints;
    [Space]
    [Header("Calculate Hit")]
    [SerializeField] private float _allowableAngle;
    [SerializeField] private float _minDistanceForLongThrow;
    [SerializeField] private float _minDistanceForMiddleThrow;
    [SerializeField, Range(0, 1)] private float _necessaryForceForLongThrow;
    [SerializeField, Range(0, 1)] private float _necessaryForceForMiddleThrow;
    [SerializeField, Range(0, 1)] private float _necessaryForceForCloseThrow;
    [SerializeField, Range(0, 1)] private float _permissibleVariationForLongThrow;
    [SerializeField, Range(0, 1)] private float _permissibleVariationForMiddleThrow;
    [SerializeField, Range(0, 1)] private float _permissibleVariationForCloseThrow;

    private Vector2 _inputDirection;
    private Vector2 _throwDirection;
    private float _throwPower;
    private float _minNecassaryForce;
    private float _maxNecassaryForce;
    private float _throwAngle;

    public void SetPower(float power) => _throwPower = power;

    public void SetInputDirection(Vector2 inputDirection) => _inputDirection = inputDirection;
    
    private void CalculateAngleHit(Vector2 inputDirection)
    {
        Vector2 planeTargetPosition = new Vector2(GoalPoint.transform.position.x, GoalPoint.transform.position.z);
        Vector2 planePlayerPosition = new Vector2(transform.position.x, transform.position.z);

        _throwDirection = planeTargetPosition - planePlayerPosition;

        _throwAngle = Vector2.Angle(_throwDirection, inputDirection);

        CalculateDistance();

        Debug.Log("Distance: " + Distance);
    }

    protected override BasketPoint CalculateThrowPoint()
    {
        CalculateAngleHit(_inputDirection);
        CalculateNecassaryForce();

        if (_throwPower > _maxNecassaryForce)
            return OverpowerMissPoints[Random.Range(0, OverpowerMissPoints.Length)];
        else if (_throwPower < _minNecassaryForce)
            return UnderpowerMissPoints[Random.Range(0, UnderpowerMissPoints.Length)];
        else if (_throwAngle < _allowableAngle)
            return GoalPoint;
        else
            return _missPoints[Random.Range(0, _missPoints.Length)]; 
    }

    protected override void CalculateDistance() => Distance = _throwDirection.magnitude;

    private void CalculateNecassaryForce()
    {
        if (Distance > _minDistanceForLongThrow)
        {
            _minNecassaryForce = Mathf.Clamp01(_necessaryForceForLongThrow - _permissibleVariationForLongThrow);
            _maxNecassaryForce = Mathf.Clamp01(_necessaryForceForLongThrow + _permissibleVariationForLongThrow);
        }
        else if (Distance > _minDistanceForMiddleThrow)
        {
            _minNecassaryForce = Mathf.Clamp01(_necessaryForceForMiddleThrow - _permissibleVariationForMiddleThrow);
            _maxNecassaryForce = Mathf.Clamp01(_necessaryForceForMiddleThrow + _permissibleVariationForMiddleThrow);
        }
        else
        {
            _minNecassaryForce = Mathf.Clamp01(_necessaryForceForCloseThrow - _permissibleVariationForCloseThrow);
            _maxNecassaryForce = Mathf.Clamp01(_necessaryForceForCloseThrow + _permissibleVariationForCloseThrow);
        }
    }
}

using UnityEngine;

public class PlayerBallThrower : BallThrower
{
    [Header("Points")]
    [SerializeField] private BasketPoint[] _missPoints;
    [Space]
    [Header("Calculate Hit")]
    [SerializeField, Range(0, 1)] private float _necessaryForceForLongThrow;
    [SerializeField, Range(0, 1)] private float _necessaryForceForMiddleThrow;
    [SerializeField, Range(0, 1)] private float _necessaryForceForCloseThrow;

    private Vector2 _inputDirection;
    private Vector2 _throwDirection;
    private float _throwPower;
    private float _minNecassaryForce;
    private float _maxNecassaryForce;
    private float _throwAngle;
    private float _accuracy;
    private float _allowableAngle;
    private float _permissibleVariationForse;

    private void Awake()
    {
        _accuracy = GetComponent<PlayerCharacteristics>().GetAccuracy();

        CalculateAccuracy();
    }

    public void SetPower(float power) => _throwPower = power;

    public void SetInputDirection(Vector2 inputDirection) => _inputDirection = inputDirection;
    
    private void CalculateAngleHit(Vector2 inputDirection)
    {
        Vector2 planeTargetPosition = new Vector2(GoalPoint.transform.position.x, GoalPoint.transform.position.z);
        Vector2 planePlayerPosition = new Vector2(transform.position.x, transform.position.z);

        _throwDirection = planeTargetPosition - planePlayerPosition;

        _throwAngle = Vector2.Angle(_throwDirection, inputDirection);

        CalculateDistance();
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
        if (Distance > Constants.ThreePointDistance)
        {
            _minNecassaryForce = Mathf.Clamp(_necessaryForceForLongThrow - _permissibleVariationForse, 0, 0.99f);
            _maxNecassaryForce = Mathf.Clamp(_necessaryForceForLongThrow + _permissibleVariationForse, 0 , 0.99f);
        }
        else if (Distance > Constants.MiddlePointDistance)
        {

            _minNecassaryForce = Mathf.Clamp(_necessaryForceForMiddleThrow - _permissibleVariationForse, 0, 0.99f);
            _maxNecassaryForce = Mathf.Clamp(_necessaryForceForMiddleThrow + _permissibleVariationForse, 0, 0.99f);
        }
        else
        {
            _minNecassaryForce = Mathf.Clamp(_necessaryForceForCloseThrow - _permissibleVariationForse, 0, 0.99f);
            _maxNecassaryForce = Mathf.Clamp(_necessaryForceForCloseThrow + _permissibleVariationForse, 0, 0.99f);
        }
    }

    private void CalculateAccuracy()
    {
        _allowableAngle = 9f + _accuracy / 10f;
        _permissibleVariationForse = 0.1f + _accuracy / 1500f;
    }
}

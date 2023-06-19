using UnityEngine;

public class BallThrower : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private BasketPoint _goalPoint;
    [SerializeField] private BasketPoint[] _missPoints;
    [SerializeField] private BasketPoint[] _overpowerMissPoints;
    [SerializeField] private BasketPoint[] _underpowerMissPoints;
    [Space]
    [Header("Throw Settings")]
    [SerializeField] private float _throwHewight;
    [SerializeField] private float _throwSpeed;
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

    private Ball _ball;
    private BasketPoint _aimPoint;
    private Vector2 _inputDirection;
    private Vector2 _throwDirection;
    private float _throwPower;
    private float _minNecassaryForce;
    private float _maxNecassaryForce;
    private float _distance;
    private float _throwAngle;

    public void SetBall(Ball ball) => _ball = ball;

    public void SetPower(float power) => _throwPower = power;

    public void SetInputDirection(Vector2 inputDirection) => _inputDirection = inputDirection;

    public void Throw()
    {
        if (_ball != null)
        {
            _ball.transform.parent = null;

            _aimPoint = CalculateThrowPoint();

            _ball.StartThrow(_aimPoint, _throwHewight, _throwSpeed);

            _ball = null;
        }
    }

    public void LookAtGoal()
    {
        Vector3 rotateDirection = _goalPoint.transform.position - transform.position;
        rotateDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(rotateDirection);
    }

    private void CalculateAngleHit(Vector2 inputDirection)
    {
        Vector2 planeTargetPosition = new Vector2(_goalPoint.transform.position.x, _goalPoint.transform.position.z);
        Vector2 planePlayerPosition = new Vector2(transform.position.x, transform.position.z);

        _throwDirection = planeTargetPosition - planePlayerPosition;

        _throwAngle = Vector2.Angle(_throwDirection, inputDirection);

        _distance = _throwDirection.magnitude;
        Debug.Log(_distance);
    }

    private BasketPoint CalculateThrowPoint()
    {
        CalculateAngleHit(_inputDirection);
        CalculateNecassaryForce();

        if (_throwPower > _maxNecassaryForce)
            return _overpowerMissPoints[Random.Range(0, _overpowerMissPoints.Length)];
        else if (_throwPower < _minNecassaryForce)
            return _underpowerMissPoints[Random.Range(0, _underpowerMissPoints.Length)];
        else if (_throwAngle < _allowableAngle)
            return _goalPoint;
        else
            return _missPoints[Random.Range(0, _missPoints.Length)]; 
    }

    private void CalculateNecassaryForce()
    {
        if (_distance > _minDistanceForLongThrow)
        {
            _minNecassaryForce = Mathf.Clamp01(_necessaryForceForLongThrow - _permissibleVariationForLongThrow);
            _maxNecassaryForce = Mathf.Clamp01(_necessaryForceForLongThrow + _permissibleVariationForLongThrow);
        }
        else if (_distance > _minDistanceForMiddleThrow)
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

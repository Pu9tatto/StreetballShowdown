using UnityEngine;

public class FreeKick : MonoBehaviour
{
    [SerializeField] private Transform[] _freeKickPoints2Points;
    [SerializeField] private Transform[] _freeKickPoints3Points;

    private Transform[] _playerFreeKickPoints;
    private Transform[] _enemyFreeKickPoints;

    private Vector3 _freeKickPoint = new Vector3 (0,5,0);

    private void Start()
    {
        _playerFreeKickPoints = _freeKickPoints2Points;
        _enemyFreeKickPoints = _freeKickPoints2Points;
    }

    public void TransformBallToFreeKickPoint(Ball ball)
    {
        if (ball.Owner == Ball.BallOwner.Player)
            _freeKickPoint = _playerFreeKickPoints[Random.Range(0, _playerFreeKickPoints.Length)].position;
        else if (ball.Owner == Ball.BallOwner.Enemy)
            _freeKickPoint = _enemyFreeKickPoints[Random.Range(0, _freeKickPoints2Points.Length)].position;

        ball.transform.position = _freeKickPoint;
        ball.StopVelosity();
    }

    public void TurnThreePointZoneForPlayer() => _playerFreeKickPoints = _freeKickPoints3Points;

    public void TurnThreePointZoneForEnemy() => _enemyFreeKickPoints = _freeKickPoints3Points;

}

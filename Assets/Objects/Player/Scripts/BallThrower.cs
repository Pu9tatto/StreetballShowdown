using UnityEngine;

public class BallThrower : MonoBehaviour
{
    [SerializeField] private Transform _goalPoint;
    [SerializeField] private float _throwHewight;
    [SerializeField] private float _throwDutation;

    private Ball _ball;

    public void SetBall(Ball ball) => _ball = ball;

    public void Throw()
    {
        if(_ball != null)
        {
            _ball.transform.parent = null;

            LookAt(_goalPoint);

            _ball.StartThrow(_goalPoint, _throwHewight, _throwDutation);
            _ball = null;
        }
    }

    private void LookAt(Transform target)
    {
        Vector3 rotateDirection = target.position - transform.position;
        rotateDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(rotateDirection);
    }
}

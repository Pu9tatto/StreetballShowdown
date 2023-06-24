using UnityEngine;

public class CatchBallTransit : Transition
{
    [SerializeField] private Transform _pointInHand;
    [SerializeField] protected Ball.BallOwner _owner;

    private BallThrower _ballThrower;

    private int _halfHeightFactor = 2;

    private void Awake()
    {
        _ballThrower = GetComponent<BallThrower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            if(ball.Owner == _owner)
            {
                PickBall(ball);
                _ballThrower.SetBall(ball);
                NeedTransit = true;
            }
        }
    }

    private void PickBall(Ball ball)
    {
        ball.MakeKinematic();

        Vector3 modifiedPointInHand = new Vector3(_pointInHand.position.x,
            _pointInHand.position.y - ball.transform.localScale.y / _halfHeightFactor, _pointInHand.position.z);

        ball.transform.position = modifiedPointInHand;

        ball.transform.parent = gameObject.transform;
    }
}

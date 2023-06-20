using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DribbleTransit : Transition
{
    [SerializeField] private Transform _pointInHand;
    [SerializeField] private Transform _pointInFall;
    [SerializeField] private float _dribbleDuration = 0.5f;
    [SerializeField] private BallThrower _ballThrower;

    private int _halfHeightFactor = 2;

    private void Awake()
    {
        _ballThrower = GetComponent<BallThrower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            PickBall(ball);
            _ballThrower.SetBall(ball);
            NeedTransit = true; 
        }
    }

    private void PickBall(Ball ball)
    {
        ball.MakeKinematic();

        Vector3 modifiedPointInHand = new Vector3(_pointInHand.position.x,
            _pointInHand.position.y - ball.transform.localScale.y / _halfHeightFactor, _pointInHand.position.z);

        float modifiedPointInFallY = _pointInFall.position.y + ball.transform.localScale.y / _halfHeightFactor;

        ball.transform.position = modifiedPointInHand;

        ball.transform.parent = gameObject.transform;

        ball.StartDribble(modifiedPointInHand.y, modifiedPointInFallY, _dribbleDuration);
    }
}

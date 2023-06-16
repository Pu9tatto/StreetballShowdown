using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class BallPicker : MonoBehaviour
{
    [SerializeField] private Transform _pointInHand;
    [SerializeField] private Transform _pointInFall;
    [SerializeField] private float _dribbleDuration = 0.5f;
    [SerializeField] private BallThrower _ballThrower;

    private PlayerMovement _movement;
    private int _halfHeightFactor = 2;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _ballThrower = GetComponent<BallThrower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            _movement.PickBall();
            PickBall(ball);
            _ballThrower.SetBall(ball);
        }
    }

    private void PickBall(Ball ball)
    {
        ball.MakeKinematic();
        ball.transform.parent = gameObject.transform;

        Vector3 modifiedPointInHand = new Vector3(_pointInHand.position.x,
            _pointInHand.position.y - ball.transform.localScale.y / _halfHeightFactor, _pointInHand.position.z);

        float modifiedPointInFallY = _pointInFall.position.y + ball.transform.localScale.y / _halfHeightFactor;

        ball.transform.position = modifiedPointInHand;

        ball.StartDribble(modifiedPointInHand.y, modifiedPointInFallY, _dribbleDuration);
    }
}

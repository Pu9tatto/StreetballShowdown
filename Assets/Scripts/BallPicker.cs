using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class BallPicker : MonoBehaviour
{
    [SerializeField] private Transform _pointInHand;
    [SerializeField] private Transform _pointInFall;
    [SerializeField] private float _dribbleDuration = 0.5f;

    private PlayerAnimation _playerAnimation;
    private int _halfHeightFactor = 2;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            _playerAnimation?.SetDribble(true);
            PickBall(ball);
        }
    }

    private void PickBall(Ball ball)
    {
        ball.transform.parent = gameObject.transform;
        ball.GetComponent<Collider>().enabled = false;

        Vector3 modifiedPointInHand = new Vector3(_pointInHand.position.x,
            _pointInHand.position.y - ball.transform.localScale.y / _halfHeightFactor, _pointInHand.position.z);

        float modifiedPointInFallY = _pointInFall.position.y + ball.transform.localScale.y / _halfHeightFactor;

        ball.transform.position = modifiedPointInHand;

        ball.StartDribble(modifiedPointInHand.y, modifiedPointInFallY, _dribbleDuration);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TwentyOneScoreCounter : MonoBehaviour
{
    [SerializeField] private ScoreWidget _scoreWidget;
    [SerializeField] private float _delay = 0.5f;

    [SerializeField] private UnityEvent<Ball> _goalEvent;

    private Collider _collider;
    private int _addedCloseZoneScore = 2;
    private int _addedLongZoneScore = 3;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            AddScore(ball);

            _goalEvent?.Invoke(ball);

            StartCoroutine(DelayScoreCounter());
        }
    }

    private IEnumerator DelayScoreCounter()
    {
        _collider.enabled = false;

        yield return new WaitForSeconds(_delay);

        _collider.enabled = true;
    }

    private void AddScore(Ball ball)
    {
        ball.SwapOwner();

        int addedScore = ball.ThrowDistance < Constants.ThreePointDistance ?
             _addedCloseZoneScore : _addedLongZoneScore;

        _scoreWidget.AddScore(addedScore, ball.Owner != Ball.BallOwner.Enemy);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class ScoreWidget : MonoBehaviour
{
    [SerializeField] protected ScoreView _playerTextView;
    [SerializeField] protected UnityEvent GameOverEvent;

    protected int _playerScore;

    protected virtual void Awake()
    {
        _playerScore = 0;
    }

    public virtual void AddScore(int value, bool isPlayer)
    {
    }

    protected virtual void FinishGame(bool isWin)
    {
        GameOverEvent?.Invoke();
    }
}

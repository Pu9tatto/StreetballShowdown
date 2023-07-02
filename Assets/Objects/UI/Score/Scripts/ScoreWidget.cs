using UnityEngine;
using UnityEngine.Events;

public class ScoreWidget : MonoBehaviour
{
    [SerializeField] protected IntValueViewer _playerTextView;
    [SerializeField] protected UnityEvent GameOverEvent;
    [SerializeField] protected UnityEvent<bool> GameOverIsWinEvent;

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
        GameOverIsWinEvent?.Invoke(isWin);
    }
}

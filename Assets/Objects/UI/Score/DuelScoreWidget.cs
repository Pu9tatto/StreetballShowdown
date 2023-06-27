using System.Collections;
using UnityEngine;

public class DuelScoreWidget : ScoreWidget
{
    [SerializeField] private int _gameOverScore = 21;
    [SerializeField] private ScoreView _enemyTextView;
    [SerializeField] private TextView _title;
    [Header("Timer")]
    [SerializeField] private int _fullSecondsTime = 180;
    [SerializeField] private TimerView _timerView;

    private int _enemyScore;
    private bool _isTimeOver = false;

    protected override void Awake()
    {
        base.Awake();
        _enemyScore = 0;
    }
    private void Start()
    {
        StartCoroutine(StartTimer(_fullSecondsTime));
    }

    public override void AddScore(int value, bool isPlayer)
    {
        if (isPlayer)
            AddPlayerScore(value);
        else
            AddEnemyScore(value);
    }

    private void AddEnemyScore(int value)
    {
        _enemyScore += value;
        _enemyTextView?.SetScore(_enemyScore);

        if (_enemyScore >= _gameOverScore || _isTimeOver)
        {
            FinishGame(false);
        }
    }

    private void AddPlayerScore(int value)
    {
        _playerScore += value;
        _playerTextView?.SetScore(_playerScore);

        if (_playerScore >= _gameOverScore || _isTimeOver)
        {
            FinishGame(true);
        }
    }

    protected override void FinishGame(bool isWin)
    {
        base.FinishGame(isWin);
        _title.SetTitle(isWin);
    }

    private IEnumerator StartTimer(int fullSecondsTime)
    {
        int time = fullSecondsTime;
        _timerView.SetTime(time);

        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            _timerView.SetTime(time);
        }

        if (_playerScore == _enemyScore)
        {
            _isTimeOver = true;
        }
        else
        {
            FinishGame(_playerScore > _enemyScore);
        }


    }
}

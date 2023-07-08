using System.Collections;
using UnityEngine;

public class DuelScoreWidget : ScoreWidget
{
    [SerializeField] protected IRewardWidget _rewardWidget;
    [SerializeField] private int _gameOverScore = 11;
    [SerializeField] private IntValueViewer _enemyTextView;
    [SerializeField] protected EndTitleView _title;
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
    protected virtual void Start()
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

    public void Reset()
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer(_fullSecondsTime));
        _enemyScore = 0;
        _playerScore = 0;
        _enemyTextView?.SetValue(_enemyScore);
        _playerTextView?.SetValue(_playerScore);

    }

    private void AddEnemyScore(int value)
    {
        _enemyScore += value;
        _enemyTextView?.SetValue(_enemyScore);

        if (_enemyScore >= _gameOverScore || _isTimeOver)
        {
            FinishGame(false);
        }
    }

    private void AddPlayerScore(int value)
    {
        _playerScore += value;
        _playerTextView?.SetValue(_playerScore);

        if (_playerScore >= _gameOverScore || _isTimeOver)
        {
            FinishGame(true);
        }
    }

    protected override void FinishGame(bool isWin)
    {
        base.FinishGame(isWin);
        _title.SetTitle(isWin);
        _rewardWidget?.Reward(isWin);
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

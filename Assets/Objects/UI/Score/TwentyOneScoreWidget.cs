using UnityEngine;

public class TwentyOneScoreWidget : ScoreWidget
{
    [SerializeField] private int _gameOverScore = 21;
    [SerializeField] private ScoreView _enemyTextView;
    [SerializeField] private TextView _title;
    [SerializeField] private FreeKick _freeKick;

    private int _enemyScore;

    protected override void Awake()
    {
        base.Awake();
        _enemyScore = 0;
    }

    public override void AddScore(int value, bool isPlayer)
    {
        if (isPlayer)
            AddPlayerScore(value);
        else
            AddEnemyScore(value);
    }

    public void AddPlayerScore(int value)
    {
        _playerScore += value;

        if (_playerScore == _gameOverScore)
        {
            FinishGame(true);
        }
        else if (_playerScore + value > _gameOverScore)
        {
            if (value == 2)
            {
                _freeKick.TurnThreePointZoneForPlayer();
                _playerScore -= value;
            }
            else
            {
                FinishGame(true);
            }
        }

        _playerTextView?.SetScore(_playerScore);
    }

    public void AddEnemyScore(int value)
    {
        _enemyScore += value;

        if (_enemyScore == _gameOverScore)
        {
            FinishGame(false);
        }
        else if (_enemyScore + value > _gameOverScore)
        {
            if (value == 2)
            {
                _freeKick.TurnThreePointZoneForEnemy();
                _enemyScore -= value;
            }
            else
            {
                FinishGame(false);
            }
        }

        _enemyTextView?.SetScore(_enemyScore);
    }

    protected override void FinishGame(bool isWin)
    {
        base.FinishGame(isWin);
        _title.SetTitle(isWin);
    }

}

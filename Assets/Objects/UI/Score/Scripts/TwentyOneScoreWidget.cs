using UnityEngine;

public class TwentyOneScoreWidget : ScoreWidget
{
    [SerializeField] private RewardWidget _rewardWidget;
    [SerializeField] private int _gameOverScore = 21;
    [SerializeField] private IntValueViewer _enemyTextView;
    [SerializeField] private EndTitleView _title;
    [SerializeField] private FreeKick _freeKick;

    private int _enemyScore;
    private bool _isLastPlayerHit = false;
    private bool _isLastEnemyHit = false;


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
        else if (_playerScore >= _gameOverScore - 3 && _isLastPlayerHit == false)
        {
            _isLastPlayerHit = true;
            _freeKick.TurnThreePointZoneForPlayer();
        }
        else if (_playerScore > _gameOverScore)
        {
            if (value == 2)
            {
                _playerScore -= value;
            }
            else
            {
                FinishGame(true);
            }
        }

        _playerTextView?.SetValue(_playerScore);
    }

    public void AddEnemyScore(int value)
    {
        _enemyScore += value;

        if (_enemyScore == _gameOverScore)
        {
            FinishGame(false);
        }
        else if (_enemyScore >= _gameOverScore - 3 && _isLastEnemyHit == false)
        {
            _isLastEnemyHit = true;
            _freeKick.TurnThreePointZoneForEnemy();
        }
        else if (_enemyScore > _gameOverScore)
        {
            if (value == 2)
            {
                _enemyScore -= value;
            }
            else
            {
                FinishGame(false);
            }
        }

        _enemyTextView?.SetValue(_enemyScore);
    }

    protected override void FinishGame(bool isWin)
    {
        base.FinishGame(isWin);
        _title.SetTitle(isWin);
        _rewardWidget.Reward(isWin);
    }

}

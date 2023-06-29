using System.Collections;
using UnityEngine;

public class TrainingScoreWidget : ScoreWidget
{
    [Header("Timer")]
    [SerializeField] private int _fullSecondsTime = 180;
    [SerializeField] private TimerView _timerView;

    private void Start()
    {
        StartCoroutine(StartTimer(_fullSecondsTime));
    }

    public override void AddScore(int value, bool isPlayer)
    {
        _playerScore += value;
        _playerTextView?.SetValue(_playerScore);
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

        GameOverEvent?.Invoke();
    }
}

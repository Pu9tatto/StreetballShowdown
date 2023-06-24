using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _fullSecondsTime = 180;
    [SerializeField] private TimerView _timerView;

    [SerializeField] private UnityEvent _timerOverEvent;

    private void Start()
    {
        StartCoroutine(StartTimer(_fullSecondsTime));
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

        _timerOverEvent?.Invoke();
    }
}

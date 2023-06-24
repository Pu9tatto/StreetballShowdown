using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TimerView : MonoBehaviour
{
    private TMP_Text _timeText;
    private int _secondsPerMinute = 60;

    private void Awake()
    {
        _timeText = GetComponent<TMP_Text>();
    }

    public void SetTime(int time)
    {
        int minutes = time / _secondsPerMinute;
        int seconds = time % _secondsPerMinute;
        string secondsText = seconds < 10 ? "0" + seconds : seconds.ToString();

        _timeText.text = minutes.ToString() + " : " + secondsText;
    }
}

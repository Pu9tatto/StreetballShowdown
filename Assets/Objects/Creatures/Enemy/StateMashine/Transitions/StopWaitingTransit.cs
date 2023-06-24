using System.Collections;
using UnityEngine;

public class StopWaitingTransit : Transition
{
    [SerializeField] private float _timeForWait;

    private float _currentTime;

    protected override void OnEnable()
    {
        base.OnEnable();
        _currentTime = _timeForWait;
    }

    private void Update()
    {
        _currentTime-=Time.deltaTime;
        if (_currentTime < 0)
            NeedTransit = true;
    }
}

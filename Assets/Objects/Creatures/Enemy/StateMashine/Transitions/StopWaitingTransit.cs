using UnityEngine;

public class StopWaitingTransit : Transition
{
    [SerializeField] private PlayerCharacteristics _playerCharacteristics;
    
    private float _enemyHandling;
    private float _playerHandling;
    private float _currentTime;
    private float _timeForWait;
    private float _defaultWaitingTime = 0.5f;
    private int _handling—oefficient = 1000;

    protected override void OnEnable()
    {
        base.OnEnable();
        _currentTime = _timeForWait;
    }

    private void Awake()
    {
        CalculateTimeForWait();
    }

    private void Update()
    {
        _currentTime-=Time.deltaTime;
        if (_currentTime < 0)
            NeedTransit = true;
    }

    private void CalculateTimeForWait()
    {
        _enemyHandling = GetComponent<EnemyCharacteristics>().GetHandling();
        _playerHandling = _playerCharacteristics.GetHandling();

        _timeForWait = _defaultWaitingTime + (_playerHandling - _enemyHandling) / _handling—oefficient;

        _timeForWait = Mathf.Clamp01(_timeForWait);
    }
}

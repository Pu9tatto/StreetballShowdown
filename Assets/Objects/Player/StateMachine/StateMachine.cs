using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset()
    {
        _currentState = _firstState;

        if (_currentState != null)
        {
            _currentState.Enter();
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        _currentState.Enter();
    }
}

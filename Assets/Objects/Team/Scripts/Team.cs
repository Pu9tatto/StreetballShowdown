using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField] private BallThrower _ballThrower;
    [SerializeField] private CreatureMovement _movement;

    private int _score;
    private Stage _currentStage;

    private void OnEnable()
    {
        _ballThrower.IsPickedBall += OnPickedBall;
    }

    private void OnDisable()
    {
        _ballThrower.IsPickedBall -= OnPickedBall;
    }

    private void Start()
    {
        _currentStage = Stage.DroppedBall;
    }
    private void OnPickedBall(bool IsPickedBall)
    {
        _currentStage = Stage.DroppedBall;
    }

    private void OnRunOut()
    {
        _currentStage = Stage.Attack;
    }
}

public enum Stage
{
    Attack,
    Defence,
    DroppedBall
}
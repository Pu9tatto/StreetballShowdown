using UnityEngine;

public class AttackTransit : Transition
{
    [SerializeField] private PlayerBallThrower _playerBallThrower;

    protected override void OnEnable()
    {
        base.OnEnable();
        _playerBallThrower.IsPickedBall += OnTransit;
    }

    private void OnDisable()
    {
        _playerBallThrower.IsPickedBall -= OnTransit;
    }

    private void OnTransit(bool isTransit)
    {
        NeedTransit = !isTransit;
    }
}

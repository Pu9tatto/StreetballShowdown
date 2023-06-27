using UnityEngine;

public class EnemyDefenceState : EnemyState
{
    [SerializeField] private PlayerBallThrower _playerBallThrower;
    [SerializeField] private LoseBallTransit[] _loseBallTransitions;

    private void OnEnable()
    {
        _playerBallThrower.LoseBall();
    }

    private void LateUpdate()
    {
        foreach (var transit in _loseBallTransitions)
            transit.Transit();
    }
}

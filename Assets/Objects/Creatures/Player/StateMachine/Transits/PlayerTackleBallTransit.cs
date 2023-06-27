using UnityEngine;

public class PlayerTackleBallTransit : Transition
{
    [SerializeField] private EnemyBallThrower _enemyBallThrower;
    [SerializeField] private LoseBallTransit _loseBallTransition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DefenderPoint>(out DefenderPoint defenderPoint))
        {
            NeedTransit = true;
            TackleBall();
        }
    }

    private void TackleBall()
    {
        _enemyBallThrower.LoseBall();

        _loseBallTransition.Transit();

    }
}
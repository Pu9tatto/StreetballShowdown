using System.Collections;
using UnityEngine;

public class EnemyTackleBallTransit : Transition
{
    [SerializeField] private PlayerBallThrower _playerBallThrower;
    [SerializeField] private LoseBallTransit _loseBallTransition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyDefenderPoint>(out EnemyDefenderPoint enemyDefenderPoint))
        {         
            Transit();
        }
    }

    private void TackleBall()
    {
        _playerBallThrower.LoseBall();

        _loseBallTransition.Transit();
    }

    private void Transit()
    {
        NeedTransit = true;

        TackleBall();
    }
}

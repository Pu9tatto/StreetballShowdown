using UnityEngine;

public class DuelScoreCounter : ScoreCounter
{
    [SerializeField] private DribbleState _dribbleState;
    [SerializeField] private EnemyDribbleState _enemyDribbleState;

    private void OnEnable()
    {
        _dribbleState.OutOffThreePoint += OnSetAttacker;
        _enemyDribbleState.OutOffThreePoint += OnSetAttacker;
    }

    private void OnDisable()
    {
        _dribbleState.OutOffThreePoint -= OnSetAttacker;
        _enemyDribbleState.OutOffThreePoint -= OnSetAttacker;
    }

    private void OnSetAttacker(bool isPlayer) => IsPlayerAttack = isPlayer;

}

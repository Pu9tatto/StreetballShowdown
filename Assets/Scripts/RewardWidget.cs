using UnityEngine;

public class RewardWidget : MonoBehaviour
{
    [SerializeField] private int _winReward = 1000;
    [SerializeField] private int _loseReward = 20;
    [SerializeField] private IntValueViewer _rewardViewer;

    private int _reward;

    public void Reward(bool isWin)
    {
        _reward = isWin ? _winReward : _loseReward;
        _rewardViewer.SetValue(_reward);
        Data.Instance.AddGold(_reward);
    }
}

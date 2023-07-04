using UnityEngine;

public class RewardWidget : MonoBehaviour
{
    [SerializeField] private int _winReward = 100;
    [SerializeField] private int _loseReward = 0;
    [SerializeField] private IntValueViewer _rewardViewer;
    [SerializeField] private IntValueViewer _advRewardViewer;
    [SerializeField] private int _modifyAdvWinReavard = 3;

    private int _advWinReavard;
    private int _reward;
    private int _modifyAdvReavard;

    public void Reward(bool isWin)
    {
        _reward = isWin ? _winReward : _loseReward;
        _modifyAdvReavard = isWin ? _modifyAdvWinReavard : 1;
        _advWinReavard = _winReward * _modifyAdvReavard;
        _rewardViewer.SetValue(_reward);
        _advRewardViewer?.SetValue(_advWinReavard);
        Data.Instance.AddGold(_reward);
    }

    public void SetWinReward(int value)
    {
        _winReward = value;
    }
}

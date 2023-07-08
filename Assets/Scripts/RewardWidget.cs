using UnityEngine;

public class RewardWidget : MonoBehaviour
{
    [SerializeField] private int _winReward = 100;
    [SerializeField] private int _loseReward = 0;
    [SerializeField] private IntValueViewer _rewardViewer;
    [SerializeField] private IntValueViewer _advRewardViewer;
    [SerializeField] private int _modifyAdvWinReavard = 3;
    [SerializeField] private Advertising _advertising;
    [SerializeField] private GameObject _rewardAdvertising;

    private int _advWinReavard;
    private int _reward;
    private int _modifyAdvReavard;

    private void OnEnable()
    {
        _advertising.RewardedCallBack += OnAdvertisingReward;
    }

    private void OnDisable()
    {
        _advertising.RewardedCallBack -= OnAdvertisingReward;
    }

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

    private void OnAdvertisingReward()
    {
        Data.Instance.AddGold(_advWinReavard);
        _rewardAdvertising.SetActive(false);
        _rewardViewer.SetValue(_reward + _advWinReavard);
    }

    public void Reward(int level)
    {
    }
}

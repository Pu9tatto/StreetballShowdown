using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TournamentRewardWidget : MonoBehaviour
{
    [SerializeField] private TournamentWidget _tournamentWidget;

    [SerializeField] private IntValueViewer _rewardRateViewer;
    [SerializeField] private IntValueViewer _rewardGoldViewer;
    [SerializeField] private IntValueViewer _winRewardRateViewer;
    [SerializeField] private IntValueViewer _winRewardGoldViewer;

    [SerializeField] private List<int> _goldListRewards;
    [SerializeField] private List<int> _rateListRewards;

    [Header("RateCalculate")]
    [SerializeField] private int _baseRate=100;
    [SerializeField] private int _modifyRate=2;
    [SerializeField] private int _modifyDifferentRate = 25;

    [SerializeField] private Advertising _advertising;

    private int _rewardRate;
    private int _rewardGold;
    private Data _data;


    private void OnEnable()
    {
        _advertising.RewardedCallBack += OnRestartCurrentLevel;

    }

    private void OnDisable()
    {
        _advertising.RewardedCallBack -= OnRestartCurrentLevel;

    }
    private void Start()
    {
        _data = Data.Instance;
    }

    public void AddReward()
    {
        _data.AddRate(_rewardRate);
        _data.AddGold(_rewardGold);
    }

    public void SetLoseRewardView()
    {
        CalculateReward();
        _rewardRateViewer.SetValue(_rewardRate);
        _rewardGoldViewer.SetValue(_rewardGold);
    }

    public void SetWinRewardView()
    {
        CalculateReward();
        _winRewardRateViewer.SetValue(_rewardRate);
        _winRewardGoldViewer.SetValue(_rewardGold);
    }

    private void CalculateReward()
    {
        _rewardRate = Math.Max(_baseRate * _modifyRate * _data.TournamentLevel - _data.Rate / _modifyDifferentRate, 0) + _rateListRewards[_data.TournamentLevel - 1];
        _rewardGold = _goldListRewards[_data.TournamentLevel - 1];
    }

    private void OnRestartCurrentLevel()
    {
        _data.RestartTournamentLevel();
        _data.AddRate(-_rewardRate);
        _data.AddGold(-_rewardGold);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}

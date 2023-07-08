using System;
using UnityEngine;

public class TournamentScoreWidget : DuelScoreWidget
{
    [SerializeField] private GameObject _winTournamentWindow; 

    [SerializeField] private TournamentWidget _tournamentWidget;
    [SerializeField] private GameObject _goldReward;
    [SerializeField] private GameObject _rateReward;

    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _nextButton;

    [SerializeField] private TournamentRewardWidget _tournamentRewardWidget;

    private Data _data;

    protected override void Start()
    {
        base.Start();
        _data = Data.Instance;
    }

    protected override void FinishGame(bool isWin)
    {
        Console.WriteLine("!!_data.LastTournamentLevel = " + _data.LastTournamentLevel);

        if(_data.LastTournamentLevel == 7 && isWin)
        {
            Time.timeScale = 0.0f;

            _winTournamentWindow.SetActive(true);

            _tournamentRewardWidget.SetWinRewardView();
            _tournamentRewardWidget.AddReward();

            ResetLevel();
            return;
        }

        GameOverEvent?.Invoke();

        _title.SetTitle(isWin);

        _goldReward.SetActive(!isWin);
        _rateReward.SetActive(!isWin);

        _nextButton.SetActive(isWin);

        if (isWin == false)
        {
            _tournamentRewardWidget.SetLoseRewardView();
            _tournamentRewardWidget.AddReward();

            ResetLevel();

            Console.WriteLine("!!TournamentLevel = " + _data.LastTournamentLevel);

            if(_data.LastTournamentLevel > 1)
            {
                bool isCanRestartTournament = Saves.Load(Saves.IsCanRestartTournament, true);
                Console.WriteLine("!!isCanRestartTournament = "+ isCanRestartTournament);
                if (isCanRestartTournament)
                {
                    _restartButton.SetActive(true);
                    Saves.Save(Saves.IsCanRestartTournament, false);
                }
            }
        }
        else
        {
            _data.AddTournamentLevel();
        }
    }

    private void ResetLevel()
    {
        _data.ResetTournamentLevel();

        _tournamentWidget.ResetLevel();
    }
}

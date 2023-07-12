using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;

public class Data : MonoBehaviour
{
    private static Data _instance;
    public static Data Instance => _instance;

    public event UnityAction<int> GoldChanged;
    public event UnityAction<int> RateChanged;

    private int _rate;
    private int _tournamentLevel = 1;
    private int _lastTournamentLevel = 1;
    private int _gold = 0;

    private bool _isAdvertisingShow;
    private bool _isSoundOn;

    public bool IsAdvertisingShow => _isAdvertisingShow;

    public bool IsSoundOn => _isSoundOn;
    public int Gold => _gold;
    public int Rate => _rate;
    public int TournamentLevel => _tournamentLevel;

    public int LastTournamentLevel => _lastTournamentLevel;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        InitInfo();

        _isSoundOn = Saves.Load(Saves.IsSoundOn, _isSoundOn);
    }

    private void Start()
    {
        SetSound();
    }

    public void InitInfo()
    {
        _gold = Saves.Load(Saves.Gold, _gold);
        _rate = Saves.Load(Saves.Rate, _rate);

        GoldChanged?.Invoke(_gold);
        RateChanged?.Invoke(_rate);
    }

    public void SoundOn()
    {
        _isSoundOn = true;
        Saves.Save(Saves.IsSoundOn, _isSoundOn);
        SetSound();
    }

    public void SoundOff()
    {
        _isSoundOn = false;
        Saves.Save(Saves.IsSoundOn, _isSoundOn);
        SetSound();
    }

    public void StartAdvetisingShow()
    {
        _isAdvertisingShow = true;
    }

    public void StopAdvertisingShow()
    {
        _isAdvertisingShow = false;
    }

    public void AddGold(int value)
    {
        _gold += value;
        GoldChanged?.Invoke(_gold);

        Saves.Save(Saves.Gold, _gold);
    }

    public void AddRate(int value)
    {
        _rate += value;
        RateChanged?.Invoke(_rate);

        Saves.Save(Saves.Rate, _rate);

        Leaderboard.SetScore("Rating", _rate);
    }

    public void AddTournamentLevel()
    {
        _tournamentLevel++;
        _lastTournamentLevel = _tournamentLevel;
    }

    public void ResetTournamentLevel()
    {
        _tournamentLevel = 1;
    }
    public void ResetLastTournamentLevel()
    {
        _lastTournamentLevel = 1;
    }

    public void RestartTournamentLevel()
    {
        _tournamentLevel = _lastTournamentLevel;
        Saves.Save(Saves.Level, _lastTournamentLevel);
    }

    public bool TrySpendGold(int value)
    {
        if (_gold >= value)
        {
            _gold -= value;

            GoldChanged?.Invoke(_gold);

            Saves.Save(Saves.Gold, _gold);

            return true;
        }

        return false;
    }

    private void SetSound()
    {
        AudioListener.volume = _isSoundOn ? 1f : 0f;
    }

    [ContextMenu("ClearSaves")]
    private void ClearSaves()
    {
        Saves.Save(Saves.Gold, 0);
        Saves.Save(Saves.Rate, 0);
    }
}

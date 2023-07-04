using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Data : MonoBehaviour
{
    private static Data _instance;

    public static Data Instance => _instance;

    public event UnityAction<int> GoldChanged;

    private int _gold;

    private bool _isSoundOn;


    public bool IsSoundOn => _isSoundOn;
    public int Gold => _gold;

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
        _gold = Saves.Load(Saves.Gold, _gold);

        _isSoundOn = Saves.Load(Saves.IsSoundOn, _isSoundOn);

        Console.WriteLine("Gold = " + _gold);

        GoldChanged?.Invoke(_gold);
    }

    private void Start()
    {
        SetSound();
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

    public void AddGold(int value)
    {
        _gold += value;
        GoldChanged?.Invoke(_gold);

        Saves.Save(Saves.Gold, _gold);
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
    }
}

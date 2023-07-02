using System;
using UnityEngine;
using UnityEngine.Events;

public class Data : MonoBehaviour
{
    private static Data _instance;

    public static Data Instance => _instance;

    public event UnityAction<int> GoldChanged;

    private int _gold;

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
        _gold = Saves.Load("Gold", _gold);

        Console.WriteLine("Gold = " + _gold);

        GoldChanged?.Invoke(_gold);
    }

    public void AddGold(int value)
    {
        _gold += value;
        GoldChanged?.Invoke(_gold);

        Saves.Save("Gold", _gold);
    }

    public bool TrySpendGold(int value)
    {
        if (_gold >= value)
        {
            _gold -= value;

            GoldChanged?.Invoke(_gold);
            Saves.Save("Gold", _gold);

            return true;
        }

        return false;
    }

    [ContextMenu("ClearSaves")]
    private void ClearSaves()
    {
        Saves.Save("Gold", 0);
    }
}

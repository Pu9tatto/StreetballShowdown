using UnityEngine;
using UnityEngine.Events;
using Agava.YandexGames;

public class Data : MonoBehaviour
{
    private static Data _instance;

    public static Data Instance => _instance;

    public event UnityAction<int> GoldChanged;

    private int _gold = 0;

    public int Gold => _gold;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance == this)
            Destroy(gameObject);

        _gold = Saves.Load("Gold", _gold);

        DontDestroyOnLoad(gameObject);

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


            return true;
        }

        return false;
    }

    [ContextMenu("ClearSaves")]
    private void ClearSaves()
    {
    }
}

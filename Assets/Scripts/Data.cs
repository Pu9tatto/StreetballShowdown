using UnityEngine;
using UnityEngine.Events;

public class Data : MonoBehaviour
{
    private static Data _instance;

    public static Data Instance => _instance;

    public event UnityAction<int> GoldChanged;

    private int _gold = 100;

    public int Gold => _gold;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void AddGold(int value)
    {
        _gold += value;
        GoldChanged?.Invoke(_gold);
    }

    public bool TrySpendGold(int value)
    {
        if (_gold >= value)
        {
            _gold -= value;

            Debug.Log("Try Spend gold: " + value);

            GoldChanged?.Invoke(_gold);
            return true;
        }

        return false;
    }

}

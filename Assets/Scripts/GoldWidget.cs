using System;
using UnityEngine;

public class GoldWidget : MonoBehaviour
{
    [SerializeField] private IntValueViewer _goldView;

    //int gold = 0;

    //private void OnEnable()
    //{
    //    Console.WriteLine("Enable");


    //    LoadGold();
    //}

    private void Start()
    {
        Console.WriteLine("Start");

        Data.Instance.GoldChanged += OnGoldChanged;

        OnGoldChanged(Data.Instance.Gold);
    }

    private void OnDisable()
    {
        Data.Instance.GoldChanged -= OnGoldChanged;
    }

    private void OnGoldChanged(int value)
    {
        _goldView.SetValue(value);
    }

    //public void LoadGold()
    //{
    //    Console.WriteLine("StartLoad");

    //    Saves.LoadData();

    //    Console.WriteLine("ContinueLoad");

    //    gold = Saves.Load("Gold", gold);

    //    Console.WriteLine("Gold = " + gold);

    //    Data.Instance.AddGold(gold);
    //}
}

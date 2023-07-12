using Agava.YandexGames;
using System;
using UnityEngine;

public class Advertising : MonoBehaviour
{
    [SerializeField] private bool _isStartShowInterstitialAd = true;

    private Data _data;

    public event Action RewardedCallBack;


    private void Awake()
    {
        _data = Data.Instance;
    }
    private void Start()
    {
        if (_isStartShowInterstitialAd)
        {
            OnShowInterstitialButtonClick();
        }
    }

    public void OnShowInterstitialButtonClick()
    {
        InterstitialAd.Show(OnOpenAdvertising, OnCloseAdvertising);
    }

    public void OnShowVideoButtonClick()
    {
        VideoAd.Show(OnOpenAdvertising, RewardedCallBack, OnCloseAdvertising);
    }

    public void OnShowStickyAdButtonClick()
    {
        StickyAd.Show();
    }

    public void OnHideStickyAdButtonClick()
    {
        StickyAd.Hide();
    }

    private void OnOpenAdvertising()
    {
        AudioListener.pause = true;
        _data.StartAdvetisingShow();
    }

    private void OnCloseAdvertising()
    {
        AudioListener.pause = false;
        _data.StopAdvertisingShow();
    }
    private void OnCloseAdvertising(bool isClose)
    {
        AudioListener.pause = false;
        _data.StopAdvertisingShow();
    }
}

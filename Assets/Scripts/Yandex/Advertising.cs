using Agava.YandexGames;
using System;
using UnityEngine;

public class Advertising : MonoBehaviour
{
    public event Action RewardedCallBack;

    public void OnShowInterstitialButtonClick()
    {
        InterstitialAd.Show();
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
    }

    private void OnCloseAdvertising()
    {
        AudioListener.pause = false;
    }
}

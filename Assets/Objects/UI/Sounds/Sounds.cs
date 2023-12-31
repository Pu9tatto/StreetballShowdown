using Agava.WebUtility;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        if(Data.Instance.IsSoundOn == false) return;

        AudioListener.volume = inBackground ? 0f : 1f;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class SoundSwitcher : MonoBehaviour
{
    [SerializeField] private Image _soundOnImage;
    [SerializeField] private Image _soundOffImage;

    private void Awake()
    {
        if (Data.Instance.IsSoundOn)
        {
            _soundOnImage.gameObject.SetActive(true);
            _soundOffImage.gameObject.SetActive(false);
        }
        else
        {
            _soundOnImage.gameObject.SetActive(false);
            _soundOffImage.gameObject.SetActive(true);
        }
    }

    public void SwitchSound()
    {
        if (Data.Instance.IsSoundOn)
            SoundOff();
        else
            SoundOn();


    }

    private void SoundOn()
    {
        _soundOnImage.gameObject.SetActive(true);
        _soundOffImage.gameObject.SetActive(false);
        Data.Instance.SoundOn();
    }

    private void SoundOff()
    {
        _soundOnImage.gameObject.SetActive(false);
        _soundOffImage.gameObject.SetActive(true);
        Data.Instance.SoundOff();
    }
}

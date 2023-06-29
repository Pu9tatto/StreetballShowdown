using UnityEngine;
using UnityEngine.UI;

public class CharacteristicWidget : MonoBehaviour
{
    [SerializeField] private Characteristics _characteristics;
    [SerializeField] private Slider _accureateSlider;
    [SerializeField] private Slider _handlingSlider;
    [SerializeField] private Slider _speedSlider;

    private void Awake()
    {
        UpdateSliders();
    }

    private void UpdateSliders()
    {
        _accureateSlider.value = _characteristics.Accuracy;
        _handlingSlider.value = _characteristics.Handling;
        _speedSlider.value = _characteristics.Speed;
    }

    public void ImproveAccuracy()
    {
        if (Data.Instance.TrySpendGold(5000))
        {
            _characteristics.ImproveAccuracy(10);
            _accureateSlider.value = _characteristics.Accuracy;
        }
    }

    public void ImproveHandling()
    {
        if (Data.Instance.TrySpendGold(5000))
        {
            _characteristics.ImproveHandling(10);
            _handlingSlider.value = _characteristics.Handling;
        }
    }

    public void ImproveSpeed()
    {
        if (Data.Instance.TrySpendGold(5000))
        {
            _characteristics.ImproveSpeed(0.1f);
            _speedSlider.value = _characteristics.Speed;
        }
    }
}

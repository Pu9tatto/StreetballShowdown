using UnityEngine;

public class RatingWidget : MonoBehaviour
{
    [SerializeField] private IntValueViewer _rateView;

    private void Start()
    {
        Data.Instance.RateChanged += OnRateChanged;

        OnRateChanged(Data.Instance.Rate);
    }

    private void OnDisable()
    {
        Data.Instance.RateChanged -= OnRateChanged;
    }

    private void OnRateChanged(int value)
    {
        _rateView.SetValue(value);
    }
}

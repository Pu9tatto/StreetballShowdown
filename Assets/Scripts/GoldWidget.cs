using UnityEngine;

public class GoldWidget : MonoBehaviour
{
    [SerializeField] private IntValueViewer _goldView;

    private void Start()
    {
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
}

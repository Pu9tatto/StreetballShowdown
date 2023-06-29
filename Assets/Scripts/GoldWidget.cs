using UnityEngine;

public class GoldWidget : MonoBehaviour
{
    [SerializeField] private IntValueViewer _goldView;

    private void Start()
    {
        Data.Instance.GoldChanged += OnGoldChanged;
        _goldView.SetValue(Data.Instance.Gold);
    }

    private void OnDisable()
    {
        Data.Instance.GoldChanged -= OnGoldChanged;
    }

    private void OnGoldChanged(int value)
    {
        Debug.Log("Spend gold: " +  value);
        _goldView.SetValue(value);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ProgressWidget : MonoBehaviour
{
    [SerializeField] private UpgradeProgress _accuracyUpgradeProgress;
    [SerializeField] private UpgradeProgress _handlingUpgradeProgerss;
    [SerializeField] private UpgradeProgress _speedUpgradeProgress;

    [SerializeField] private Button _accuracyUpgradeProgressButton;
    [SerializeField] private Button _handlingUpgradeProgerssButton;
    [SerializeField] private Button _speedUpgradeProgressButton;

    [SerializeField] private IntValueViewer _costAccuracyUpgradeView;
    [SerializeField] private IntValueViewer _costHandlingUpgradeView;
    [SerializeField] private IntValueViewer _costSpeedUpgradeView;

    [SerializeField] private Characteristics _characteristics;
    [SerializeField] private Slider _accureateSlider;
    [SerializeField] private Slider _handlingSlider;
    [SerializeField] private Slider _speedSlider;

    private int _accuracyLevel = 0;
    private int _handlingLevel = 0;
    private int _speedLevel = 0;

    private void Start()
    {
        UpdateCharactreristics();
        UpdateUpgradeButtons();
        UpdateSliders();
    }

    private void UpdateSliders()
    {
        _accureateSlider.value = _characteristics.Accuracy;
        _handlingSlider.value = _characteristics.Handling;
        _speedSlider.value = _characteristics.Speed;
    }

    private void UpdateUpgradeButtons()
    {
        _costAccuracyUpgradeView.SetValue(_accuracyUpgradeProgress.GetNextCost(_accuracyLevel));
        _costHandlingUpgradeView.SetValue(_handlingUpgradeProgerss.GetNextCost(_handlingLevel));
        _costSpeedUpgradeView.SetValue(_speedUpgradeProgress.GetNextCost(_speedLevel));
    }

    private void UpdateCharactreristics()
    {
        _characteristics.SetAccuracy(_accuracyUpgradeProgress.GetNextProgress(_accuracyLevel));
        _characteristics.SetHandling(_handlingUpgradeProgerss.GetNextProgress(_handlingLevel));
        _characteristics.SetSpeed(_speedUpgradeProgress.GetNextProgress(_speedLevel));
    }

    public void ImproveAccuracy()
    {
        if (Data.Instance.TrySpendGold(_accuracyUpgradeProgress.GetNextCost(_accuracyLevel)))
        {
            _characteristics.SetAccuracy(_accuracyUpgradeProgress.GetNextProgress(_accuracyLevel));
            _accureateSlider.value = _characteristics.Accuracy;

            _accuracyLevel++;

            if (_accuracyLevel >= _accuracyUpgradeProgress.GetMaxLevel())
            {
                _costAccuracyUpgradeView.SetValue("-");
                _accuracyUpgradeProgressButton.enabled = false;
            }
            else
            {
                _costAccuracyUpgradeView.SetValue(_accuracyUpgradeProgress.GetNextCost(_accuracyLevel));
            }
        }
    }

    public void ImproveHandling()
    {
        if (Data.Instance.TrySpendGold(_handlingUpgradeProgerss.GetNextCost(_handlingLevel)))
        {
            _characteristics.SetHandling(_handlingUpgradeProgerss.GetNextProgress(_handlingLevel));
            _handlingSlider.value = _characteristics.Handling;

            _handlingLevel++;

            if (_handlingLevel >= _handlingUpgradeProgerss.GetMaxLevel())
            {
                _costHandlingUpgradeView.SetValue("-");
                _handlingUpgradeProgerssButton.enabled = false;
            }
            else
            {
                _costHandlingUpgradeView.SetValue(_handlingUpgradeProgerss.GetNextCost(_handlingLevel));
            }
        }
    }

    public void ImproveSpeed()
    {
        if (Data.Instance.TrySpendGold(_speedUpgradeProgress.GetNextCost(_speedLevel)))
        {
            _characteristics.SetSpeed(_speedUpgradeProgress.GetNextProgress(_speedLevel));
            _speedSlider.value = _characteristics.Speed;

            _speedLevel++;
            if (_speedLevel >= _speedUpgradeProgress.GetMaxLevel())
            {
                _costSpeedUpgradeView.SetValue("-");
                _speedUpgradeProgressButton.enabled = false;
            }
            else
            {
                _costSpeedUpgradeView.SetValue(_speedUpgradeProgress.GetNextCost(_speedLevel));
            }
        }
    }
}

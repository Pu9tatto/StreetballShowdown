using UnityEngine;
using UnityEngine.UI;

public class DificultSelector : MonoBehaviour
{
    [SerializeField] private Characteristics _easyCharacteristics;
    [SerializeField] private Characteristics _mediumCharacteristics;
    [SerializeField] private Characteristics _hardCharacteristics;

    [SerializeField] private int _mediumCost;
    [SerializeField] private int _hardCost;

    [SerializeField] private IntValueViewer _mediumCostViewer;
    [SerializeField] private IntValueViewer _hardCostViewer;

    [SerializeField] private GameObject _mediumCostEffect;
    [SerializeField] private GameObject _hardCostEffect;

    [SerializeField] private Button _mediumButton;
    [SerializeField] private Button _hardButton;

    [SerializeField] private EnemyCharacteristics _enemyCharacteristics;

    [SerializeField] private RewardWidget _rewardWidget;

    private Data _data;
    private int _winRewardModify = 3;

    private void Awake()
    {
        Time.timeScale = 0.0f;
        _data = Data.Instance;
    }

    private void Start()
    {
        SetCost();
        CheckEnoughtGold();
    }

    public void SetEasyMod()
    {
        _enemyCharacteristics.SetCharacteristics(_easyCharacteristics);
        CloseWindow();
    }

    public void SetMediumMod()
    {
        if (_data.TrySpendGold(_mediumCost))
        {
            _enemyCharacteristics.SetCharacteristics(_mediumCharacteristics);

            _rewardWidget.SetWinReward(_mediumCost * _winRewardModify);

            CloseWindow();
        }
    }

    public void SetHardMod()
    {
        if (_data.TrySpendGold(_hardCost))
        {
            _enemyCharacteristics.SetCharacteristics(_hardCharacteristics);

            _rewardWidget.SetWinReward(_hardCost * _winRewardModify);

            CloseWindow();
        }
    }

    private void CloseWindow()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    private void SetCost()
    {
        _mediumCostViewer.SetValue(_mediumCost);
        _hardCostViewer.SetValue(_hardCost);
    }

    private void CheckEnoughtGold()
    {
        _mediumCostEffect.SetActive(_data.Gold >= _mediumCost);
        _mediumButton.interactable = _data.Gold >= _mediumCost;
        _hardCostEffect.SetActive(_data.Gold >= _hardCost);
        _hardButton.interactable = _data.Gold >= _hardCost;
    }
}

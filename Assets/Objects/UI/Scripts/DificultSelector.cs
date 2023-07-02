using UnityEngine;

public class DificultSelector : MonoBehaviour
{
    [SerializeField] private Characteristics _easyCharacteristics;
    [SerializeField] private Characteristics _mediumCharacteristics;
    [SerializeField] private Characteristics _hardCharacteristics;
    [SerializeField] private EnemyCharacteristics _enemyCharacteristics;

    private void Awake()
    {
        Time.timeScale = 0.0f;
    }

    public void SetEasyMod()
    {
        _enemyCharacteristics.SetCharacteristics(_easyCharacteristics);
        CloseWindow();
    }

    public void SetMediumMod()
    {
        _enemyCharacteristics.SetCharacteristics(_mediumCharacteristics);
        CloseWindow();
    }

    public void SetHardMod()
    {
        _enemyCharacteristics.SetCharacteristics(_hardCharacteristics);
        CloseWindow();
    }

    private void CloseWindow()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}

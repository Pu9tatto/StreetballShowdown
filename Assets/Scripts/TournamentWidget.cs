using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TournamentWidget : MonoBehaviour
{
    [SerializeField] private EndGameWindowWidget _endGameWindowWidget;

    [SerializeField] private GameObject _startGameWindow;
    [SerializeField] protected DuelScoreWidget _scoreWidget;

    [SerializeField] private List<Characteristics> _characteristics;
    [SerializeField] private EnemyCharacteristics _enemyCharacteristics;

    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _nextLevelButton;

    [SerializeField] private TMP_Text _modeName;
    [SerializeField] private TMP_Text _modeNameInStartWindow;

    [SerializeField] private string _finalTextEn;
    [SerializeField] private string _finalTextRu;
    [SerializeField] private string _finalTextTr;

    private const string _enLanguage = "en";
    private const string _ruLanguage = "ru";
    private const string _trLanguage = "tr";

    private string _finalText = "Final";

    private int _enemyLevel = 1;

    private void Awake()
    {
        Time.timeScale = 0.0f;

        Init();
    }

    private void Start()
    {
        string lang = Language.Instance.CurrentLanguage;

        switch (lang)
        {
            case _enLanguage:
                _finalText = _finalTextEn;
                break;
            case _ruLanguage:
                _finalText = _finalTextRu;
                break;
            case _trLanguage:
                _finalText = _finalTextTr;
                break;
            default:
                _finalText = _finalTextEn;
                break;
        }
    }

    public void ContinueGame()
    {
        SetDificult();
    }

    public void NewGame()
    {
        ResetLevel();

        SetDificult();
    }

    public void NextLevel()
    {
        if (_enemyLevel < _characteristics.Count)
        {
            _enemyLevel++;
#if UNITY_WEBGL && !UNITY_EDITOR
        Saves.Save("Level", _enemyLevel);
#endif
        }

        _endGameWindowWidget.Restart();
    }

    public void ResetAfterLose(bool isWin)
    {
        if(isWin == false)
        {
            ResetLevel();
        }
    }

    private void SetDificult()
    {
        _enemyCharacteristics.SetCharacteristics(_characteristics[_enemyLevel - 1]);

        SetModeName();

        CloseWindow();
    }
    private void ResetLevel()
    {
        _enemyLevel = 1;

#if UNITY_WEBGL && !UNITY_EDITOR
        Saves.Save("Level", _enemyLevel);
#endif
    }

    private void CloseWindow()
    {
        Time.timeScale = 1.0f;
        _startGameWindow.SetActive(false);
    }

    private void Init()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        _enemyLevel = Saves.Load("Level", _enemyLevel);
#endif

        if (_enemyLevel == 1)
            _continueButton.interactable = false;
        else
            _continueButton.interactable = true;

        _nextLevelButton.interactable = true;

        SetModeName();
    }

    private void SetModeName()
    {
        if (_characteristics.Count == _enemyLevel)
        {
            _modeName.text = _finalText;
            _modeNameInStartWindow.text = _finalText;
            return;
        }

        float finalProgress = Mathf.Pow(2, _characteristics.Count - _enemyLevel);

        _modeName.text = "1/" + finalProgress +" "+ _finalText;
        _modeNameInStartWindow.text = "1/" + finalProgress + " " + _finalText;
    }
}


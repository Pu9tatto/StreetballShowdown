using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    private string _finalText = "Final";

    private int _enemyLevel = 1;

    private void Awake()
    {
        Time.timeScale = 0.0f;

        Init();
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


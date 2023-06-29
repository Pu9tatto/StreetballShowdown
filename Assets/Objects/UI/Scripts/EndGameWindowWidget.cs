using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameWindowWidget : MonoBehaviour
{
    [SerializeField] private EndGameWindow _endGameWindow;
    [SerializeField] private EndGameWindow _pauseGameWindow;

    public void Continue()
    {
        _pauseGameWindow.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene(Constants.MenuSceneName);
    }

    public void ShowEndGameWindow()
    {
        Time.timeScale = 0.0f;
        _endGameWindow.gameObject.SetActive(true);
    }

    public void ShowPauseGameWindow()
    {
        Time.timeScale = 0.0f;
        _pauseGameWindow.gameObject.SetActive(true);
    }
}

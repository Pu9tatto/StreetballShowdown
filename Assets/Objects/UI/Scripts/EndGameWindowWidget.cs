using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameWindowWidget : MonoBehaviour
{
    [SerializeField] private GameObject _endGameWindow;

    private const string _menuSceneNAme = "Menu";

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene(_menuSceneNAme);
    }

    public void ShowEndGameWindow()
    {
        Time.timeScale = 0.0f;
        _endGameWindow.SetActive(true);
    }
}

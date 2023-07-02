using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void InvokeTraining()
    {
        SceneManager.LoadScene(Constants.TrainingSceneName);
    }

    public void InvokeTwentyOneMode()
    {
        SceneManager.LoadScene(Constants.TwentyOneSceneName);
    }

    public void InvokeDuelMode()
    {
        SceneManager.LoadScene(Constants.DuelSceneName);
    }

    public void InvokeTournament()
    {
        SceneManager.LoadScene(Constants.TournamentSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

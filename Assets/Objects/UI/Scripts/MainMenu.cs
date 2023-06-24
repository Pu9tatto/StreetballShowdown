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
}

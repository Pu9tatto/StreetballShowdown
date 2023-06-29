using UnityEngine;

public class EndGameWindow : MonoBehaviour
{
    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }
}

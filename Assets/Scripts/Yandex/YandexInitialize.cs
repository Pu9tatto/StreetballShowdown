using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YandexInitialize : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        Saves.LoadData();

        while (Saves.IsSavesLoaded == false)
        {
            yield return null;
        }

        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}

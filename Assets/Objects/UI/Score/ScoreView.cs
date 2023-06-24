using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreView : MonoBehaviour
{
    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    public void SetScore(int value)
    {
        _scoreText.text = value.ToString();
    }
}

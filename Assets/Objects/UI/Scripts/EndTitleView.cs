using TMPro;
using UnityEngine;

public class EndTitleView : MonoBehaviour
{
    [SerializeField] private string _winText = "You Win";
    [SerializeField] private string _loseText = "You Lose";

    private TMP_Text _title;

    private void Awake()
    {
        _title = GetComponent<TMP_Text>();
    }

    public void SetTitle(bool isWin) => _title.text = isWin ? _winText : _loseText;
}

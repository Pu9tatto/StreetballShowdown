using TMPro;
using UnityEngine;

public class EndTitleView : MonoBehaviour
{
    [SerializeField] private string _winTextEn = "You Win";
    [SerializeField] private string _winTextRu = "You Win";
    [SerializeField] private string _winTextTr = "You Win";
    [SerializeField] private string _loseTextEn = "You Lose";
    [SerializeField] private string _loseTextRu = "You Lose";
    [SerializeField] private string _loseTextTr = "You Lose";

    private const string _enLanguage = "en";
    private const string _ruLanguage = "ru";
    private const string _trLanguage = "tr";

    private TMP_Text _title;
    private string _winText;
    private string _loseText;

    private void Awake()
    {
        _title = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        string lang = Language.Instance.CurrentLanguage;

        switch (lang)
        {
            case _enLanguage:
                _winText = _winTextEn;
                _loseText = _loseTextEn;
                break;
            case _ruLanguage:
                _winText = _winTextRu;
                _loseText = _loseTextRu;
                break;
            case _trLanguage:
                _winText = _winTextTr;
                _loseText = _loseTextTr;
                break;
            default:
                _winText = _winTextEn;
                _loseText = _loseTextEn;
                break;
        }
    }

    public void SetTitle(bool isWin) => _title.text = isWin ? _winText : _loseText;
}

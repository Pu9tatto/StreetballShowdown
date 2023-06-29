using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class IntValueViewer : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void SetValue(int value)
    {
        _text.text = value.ToString();
    }

    public void SetValue(string value)
    {
        _text.text = value;
    }
}

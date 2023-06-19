using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{
    [SerializeField] private float _chargeSpeed;

    private Slider _slider;
    private float _maxValue = 1.0f;
    private float _minValue = 0.0f;


    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.value = _maxValue;

        StartCoroutine(ChargeCoroutine(_chargeSpeed));
    }

    private IEnumerator ChargeCoroutine(float speed)
    {
        while (_slider.value > _minValue)
        {
            _slider.value -= speed * Time.deltaTime;
            yield return null;
        }
    }

}

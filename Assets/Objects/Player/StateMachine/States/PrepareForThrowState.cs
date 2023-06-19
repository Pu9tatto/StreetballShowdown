using UnityEngine;
using UnityEngine.UI;

public class PrepareForThrowState : State
{
    [SerializeField] private PowerSlider _powerSlider;
    [SerializeField] private BallThrower _ballThrower;

    private Slider _slider;

    private void OnEnable()
    {       
        _powerSlider.gameObject.SetActive(true);
        _ballThrower.LookAtGoal();

        _slider = _powerSlider.GetComponent<Slider>();
    }

    private void OnDisable()
    {
        _ballThrower.SetPower(1-_slider.value);
        _powerSlider.gameObject.SetActive(false);
    }
}

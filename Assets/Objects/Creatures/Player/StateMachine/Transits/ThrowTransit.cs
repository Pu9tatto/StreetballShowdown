using UnityEngine;

public class ThrowTransit : Transition
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private BallThrower _ballThrower;

    protected override void OnEnable()
    {
        base.OnEnable();

        _joystick.PointUp += OnPointUp;
    }

    private void OnDisable()
    {
        _joystick.PointUp -= OnPointUp;
    }

    private void OnPointUp()
    {
        _ballThrower.SetInputDirection(_joystick.Direction);
        NeedTransit = true;
    }
}

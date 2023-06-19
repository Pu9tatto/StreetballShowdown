using UnityEngine;

public class PointUpTransit : Transition
{
    [SerializeField] private FixedJoystick _joystick;

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
        NeedTransit = true;
    }
}

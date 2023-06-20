using UnityEngine;

public class PointDownTransit : Transition
{
    [SerializeField] private FixedJoystick _joystick;

    protected override void OnEnable()
    {
        base.OnEnable();

        _joystick.PointDown += OnPointDown;
    }

    private void OnDisable()
    {
        _joystick.PointDown -= OnPointDown;
    }

    private void OnPointDown()
    {
        NeedTransit = true;
    }
}

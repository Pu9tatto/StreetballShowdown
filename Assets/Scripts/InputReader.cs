using UnityEngine;

[RequireComponent (typeof(PlayerMovement))]
public class InputReader : MonoBehaviour, IControllable 
{
    [SerializeField] private FixedJoystick _joystick;

    public Vector2 GetDirection() => new Vector2(_joystick.Horizontal, _joystick.Vertical);

}

using UnityEngine;

[RequireComponent(typeof(PlayerBallThrower))]
public class InputReader : MonoBehaviour, IControllable 
{
    [SerializeField] private FixedJoystick _joystick;  

    public Vector2 GetDirection() => _joystick.Direction;
}

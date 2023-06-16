using UnityEngine;

[RequireComponent (typeof(PlayerMovement))]
[RequireComponent(typeof(BallThrower))]
public class InputReader : MonoBehaviour, IControllable 
{
    [SerializeField] private FixedJoystick _joystick;

    private BallThrower _ballThrower;
    private PlayerMovement _movement;   

    private void Awake()
    {
        _ballThrower = GetComponent<BallThrower>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space)) 
        {
            _ballThrower.Throw();
            _movement.TryJump();
        }
    }

    public Vector2 GetDirection() => new Vector2(_joystick.Horizontal, _joystick.Vertical);

}

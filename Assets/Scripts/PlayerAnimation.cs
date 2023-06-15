using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private readonly int _velocityKey = Animator.StringToHash("Velocity");
    private readonly int _isDribbleKey = Animator.StringToHash("IsDribble");

    private Animator _animator;
    private IControllable _controller;
    private Vector2 _direction;
    private bool _isDribble = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<IControllable>();
    }

    private void Update()
    {
        SetDirection();
        _animator.SetFloat(_velocityKey, _direction.sqrMagnitude);
        _animator.SetBool(_isDribbleKey, _isDribble);
    }

    public void SetDribble(bool isDribble) => _isDribble = isDribble;

    private void SetDirection()
    {
        _direction = _controller.GetDirection();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Ball>(out Ball ball))
        {
            _isDribble = true;
        }
    }
}

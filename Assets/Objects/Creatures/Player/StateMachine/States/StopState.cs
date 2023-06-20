using UnityEngine;

public class StopState : State
{
    private readonly int _velocityKey = Animator.StringToHash("Velocity");

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = Vector3.zero;

        Animator?.SetFloat(_velocityKey, 0);
    }
}

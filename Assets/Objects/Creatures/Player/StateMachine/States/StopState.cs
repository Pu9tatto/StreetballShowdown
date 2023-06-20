using UnityEngine;

public class StopState : State
{
    private readonly int _velocityKey = Animator.StringToHash("Velocity");

    private void OnEnable()
    {
        Animator?.SetFloat(_velocityKey, 0);
    }
}

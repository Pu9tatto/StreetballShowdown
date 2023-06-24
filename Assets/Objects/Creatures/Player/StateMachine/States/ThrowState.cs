using System.Collections;
using UnityEngine;

public class ThrowState : State
{
    [SerializeField] private PlayerBallThrower _ballThrower;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private MoveTransit _moveTransit;

    private readonly int _shootKey = Animator.StringToHash("Shoot");
    private readonly int _isDribbleKey = Animator.StringToHash("IsDribble");

    private void OnEnable()
    {
        Animator.SetTrigger(_shootKey);
        Animator.SetBool(_isDribbleKey, false);

        _ballThrower.Throw();

        StartCoroutine(JumpRoutine(transform.position));
    }

    private void OnDisable()
    {
        StopCoroutine(JumpRoutine(transform.position));
    }

    private IEnumerator JumpRoutine(Vector3 startPosition)
    {
        startPosition.y = 0;

        float timer = 0f;

        while (timer < _jumpDuration)
        {
            float jumpProgress = timer / _jumpDuration;
            float yOffset = Mathf.Sin(jumpProgress * Mathf.PI) * _jumpHeight;

            transform.position = startPosition + new Vector3(0f, yOffset, 0f);

            timer += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
        _moveTransit?.Transit();
    }
}

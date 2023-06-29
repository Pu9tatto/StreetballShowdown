using System.Collections;
using UnityEngine;

public class EnemyThrowState : State
{
    [SerializeField] private BallThrower _ballThrower;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private MoveTransit _moveTransit;
    [SerializeField] private float _waitPreapreThrow;

    private void OnEnable()
    {
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

        _ballThrower?.LookAtGoal();

        yield return new WaitForSeconds(_waitPreapreThrow);

        _ballThrower?.Throw();
        Animator.SetBool(Constants.IsDribbleKey, false);
        Animator.SetTrigger(Constants.ShootKey);

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

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _throwBounced;
    [SerializeField] private BallOwner _owner = BallOwner.None;

    private float[] _dribblePoints = new float[2];
    private int currentWaypointIndex = 0;
    private float _dribbleDuration;
    private bool _isDribble = true;
    private Coroutine _current;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private float _throwDistance;

    public float ThrowDistance => _throwDistance;
    public BallOwner Owner => _owner;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void MakeKinematic()
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }

    public void StopVelosity()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    public void SwapOwner()
    {
        if (_owner == BallOwner.Player)
            _owner = BallOwner.Enemy;
        else if( _owner == BallOwner.Enemy)
            _owner = BallOwner.Player;
    }

    public void SetOwner(BallOwner owner) => _owner = owner;

    public void StartDribble(float topPoint, float botPoint, float duration)
    {
        _dribblePoints[0] = topPoint;
        _dribblePoints[1] = botPoint;
        _dribbleDuration = duration;

        StartState(PatrolCoroutine());
    }

    public void StartThrow(Vector3 endPoint, float height, float speed, float throwDistance)
    {
        _throwDistance = throwDistance;
        Vector3 startPoint = transform.position;
        StartState(ThrowCoroutin(startPoint, endPoint, height, speed));
    }

    private void MakeNonKinematic()
    {
        _rigidbody.isKinematic = false;
        _collider.enabled = true;
    }

    private IEnumerator ThrowCoroutin(Vector3 startPoint, Vector3 endPoint, float height, float speed)
    {
        float currentMoveProgress = 0.0f;
        float maxMoveProgress = 1.0f;

        while (currentMoveProgress < maxMoveProgress)
        {
            currentMoveProgress += Time.deltaTime * speed;

            Vector3 position = CalculateParabolicPosition(startPoint, endPoint, height, currentMoveProgress);

            transform.position = position;

            yield return null;
        }

        MakeNonKinematic();

        SwapOwner();

        Vector3 throwDirection = (endPoint - startPoint) * _throwBounced;

        _rigidbody.velocity = throwDirection;
    }

    private IEnumerator PatrolCoroutine()
    {
        while (_isDribble)
        {
            float currentWaypoint = _dribblePoints[currentWaypointIndex];
            float startPositionY = transform.position.y;
            float currentPositionY;
            float elapsedTime = 0f;

            while (elapsedTime < _dribbleDuration)
            {
                elapsedTime += Time.deltaTime;
                float lerpProgress = Mathf.Clamp01(elapsedTime / _dribbleDuration);
                currentPositionY = Mathf.Lerp(startPositionY, currentWaypoint, lerpProgress);
                transform.position = new Vector3(transform.position.x, currentPositionY, transform.position.z);
                yield return null;
            }

            currentWaypointIndex = (currentWaypointIndex + 1) % _dribblePoints.Length;

            yield return null;
        }
    }

    private Vector3 CalculateParabolicPosition(Vector3 startPosition, Vector3 endPosition, float height, float moveProgress)
    {
        float deltaPath = 1.0f - moveProgress;
        float sqrMoveProgress = moveProgress * moveProgress;
        float sqrDeltaPath = deltaPath * deltaPath;

        Vector3 position = sqrDeltaPath * startPosition;
        position += 2 * deltaPath * moveProgress * (startPosition + height * Vector3.up);
        position += sqrMoveProgress * endPosition;

        return position;
    }

    private void StartState(IEnumerator corotine)
    {
        if (_current != null)
            StopCoroutine(_current);

        _current = StartCoroutine(corotine);
    }

    public enum BallOwner
    {
        None,
        Player,
        Enemy
    }
}

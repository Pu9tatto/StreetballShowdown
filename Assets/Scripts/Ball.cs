using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private float[] _points = new float[2];
    private int currentWaypointIndex = 0;
    private float _duration;
    private bool _isDribble = true;


    public void StartDribble(float topPoint, float botPoint, float duration)
    {
        _points[0] = topPoint;
        _points[1] = botPoint;
        _duration = duration;

        StartCoroutine(PatrolCoroutine());
    }

    private IEnumerator PatrolCoroutine()
    {
        while (_isDribble)
        {
            float currentWaypoint = _points[currentWaypointIndex];
            float startPositionY = transform.position.y;
            float currentPositionY;
            float elapsedTime = 0f;

            while (elapsedTime < _duration)
            {
                elapsedTime += Time.deltaTime;
                float lerpProgress = Mathf.Clamp01(elapsedTime / _duration);
                currentPositionY = Mathf.Lerp(startPositionY, currentWaypoint, lerpProgress);
                transform.position = new Vector3(transform.position.x, currentPositionY, transform.position.z);
                yield return null;
            }

            currentWaypointIndex = (currentWaypointIndex + 1) % _points.Length;

            yield return null;
        }
    }
}

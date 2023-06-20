using UnityEngine;

public class StopRunAwayTransit : Transition
{
    [SerializeField] private float _distanceForRunAway = 6.75f;
    [SerializeField] private BasketPoint _goalPoint;

    private void Update()
    {
        Vector2 heading = new Vector2(_goalPoint.transform.position.x - transform.position.x, _goalPoint.transform.position.z - transform.position.z);
        float distance = heading.sqrMagnitude;

        if (distance > _distanceForRunAway * _distanceForRunAway)
            NeedTransit = true;
    }
}

using UnityEngine;

public class StopRunAwayTransit : Transition
{
    [SerializeField] private BasketPoint _goalPoint;

    private void Update()
    {
        Vector2 heading = new Vector2(_goalPoint.transform.position.x - transform.position.x, _goalPoint.transform.position.z - transform.position.z);
        float sqrDistance = heading.sqrMagnitude;

        if (sqrDistance > Constants.ThreePointDistance * Constants.ThreePointDistance)
            NeedTransit = true;
    }
}

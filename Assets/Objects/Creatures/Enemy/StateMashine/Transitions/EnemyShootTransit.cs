using UnityEngine;

public class EnemyShootTransit : Transition
{
    [SerializeField] private float _minDistanceForShoot;
    [SerializeField] private float _maxDistanceForShoot;
    [SerializeField] private BasketPoint _goalPoint;
    
    private float _distanceForShoot;

    protected override void OnEnable()
    {
        base.OnEnable();

        _distanceForShoot = Random.Range(_minDistanceForShoot, _maxDistanceForShoot);
    }

    private void Update()
    {
        Vector2 heading = new Vector2(_goalPoint.transform.position.x - transform.position.x, _goalPoint.transform.position.z - transform.position.z);
        float distance = heading.sqrMagnitude;

        if (distance<_distanceForShoot* _distanceForShoot)
            NeedTransit = true;
    }
}

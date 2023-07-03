using UnityEngine;

public class FallChecker : MonoBehaviour
{
    private Vector3 _freeKickPoint = new Vector3(0, 5, 0);

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            ball.transform.position = _freeKickPoint;
            ball.StopVelosity();
        }
    }
}

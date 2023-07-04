using UnityEngine;
using UnityEngine.Events;

public class EnterTriggerBall : MonoBehaviour
{
    [SerializeField] private UnityEvent _ballTriggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Ball>(out Ball ball))
        {
            _ballTriggerEvent?.Invoke();
        }
    }
}

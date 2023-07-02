using UnityEngine;

public class EnemyCharacteristics : MonoBehaviour
{
    [SerializeField] private Characteristics _characteristics;

    public float GetSpeed() => _characteristics.Speed;

    public float GetAccuracy() => _characteristics.Accuracy;

    public float GetHandling() => _characteristics.Handling;

    public void SetCharacteristics(Characteristics characteristics)
    {
        _characteristics = characteristics;
    }
}

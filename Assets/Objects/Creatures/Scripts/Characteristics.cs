using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "Characteristics", order = 51)]
[Serializable]
public class Characteristics : ScriptableObject
{
    [SerializeField] private float _accuracy;
    [SerializeField] private float _handling;
    [SerializeField] private float _speed;

    public float Speed => _speed;
    public float Accuracy => _accuracy;
    public float Handling => _handling;

    public void ImproveAccuracy(float value)
    {
        _accuracy += value;
    }

    public void ImproveHandling(float value)
    {
        _handling += value;
    }

    public void ImproveSpeed(float value)
    {
        _speed += value;
    }
}

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

    public void SetAccuracy(float value)
    {
        _accuracy = value;
    }

    public void SetHandling(float value)
    {
        _handling = value;
    }

    public void SetSpeed(float value)
    {
        _speed = value;
    }

    public void Load()
    {

    }
}

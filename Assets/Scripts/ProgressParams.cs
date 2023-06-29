using System;
using UnityEngine;

[Serializable]
public class ProgressParams 
{
    [SerializeField] private int _cost;
    [SerializeField] private float _progress;

    public int Cost=> _cost;
    public float Progress => _progress;
}

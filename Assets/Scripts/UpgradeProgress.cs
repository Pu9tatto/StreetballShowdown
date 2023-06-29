using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeProgress", menuName = "UpgradeProgress", order = 51)]
[Serializable]
public class UpgradeProgress : ScriptableObject
{
    [SerializeField] private ProgressParams[] _progressParams;

    public int GetNextCost(int level)
    {
        if (level >= _progressParams.Length)
            return -1;

        return _progressParams[level].Cost;
    }

    public float GetNextProgress(int level)
    {
        if (level >= _progressParams.Length)
            return -1;

        return _progressParams[level].Progress;
    }

    public int GetMaxLevel() => _progressParams.Length;
}

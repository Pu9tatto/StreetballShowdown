using UnityEngine;

static class Constants
{
    static public readonly int ShootKey = Animator.StringToHash("Shoot");
    static public readonly int IsDribbleKey = Animator.StringToHash("IsDribble");
    static public readonly int IsDefenceKey = Animator.StringToHash("IsDefence");
    static public readonly int VelocityKey = Animator.StringToHash("Velocity");


    public const string TrainingSceneName = "Training";
    public const string TwentyOneSceneName = "TwentyOne";
    public const string DuelSceneName = "Duel";

    public const float ThreePointDistance = 6.75f;
}

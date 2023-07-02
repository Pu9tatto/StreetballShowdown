using UnityEngine;

static class Constants
{
    static public readonly int ShootKey = Animator.StringToHash("Shoot");
    static public readonly int ResetKey = Animator.StringToHash("Reset");
    static public readonly int IsDribbleKey = Animator.StringToHash("IsDribble");
    static public readonly int IsDefenceKey = Animator.StringToHash("IsDefence");
    static public readonly int VelocityKey = Animator.StringToHash("Velocity");


    public const string TrainingSceneName = "Training";
    public const string TwentyOneSceneName = "TwentyOne";
    public const string DuelSceneName = "Duel";
    public const string TournamentSceneName = "Tournament";
    public const string MenuSceneName = "Menu";

    public const float MiddlePointDistance = 4.0f;
    public const float ThreePointDistance = 6.75f;
    public const float DribbleModifySpeed = 0.8f;

}

using UnityEngine;

public class PlayerDuelDribbleTransit : DribbleTransit
{
    protected override void PickBall(Ball ball)
    {
        base.PickBall(ball);

        ball.SetOwner(Ball.BallOwner.Player);
    }
}

public class ResetingState : State
{
    private PlayerModel[] _players;
    private Ball _ball;

    public ResetingState(PlayerModel[] players, Ball ball)
    {
        _players = players;
        _ball = ball;
    }

    public override void OnEnter()
    {
        foreach (PlayerModel player in _players)
        {
            if (player != null)
            {
                player.ResetPosition();
            }
        }

        if (_ball != null)
        {
            _ball.ResetPosition();
        }
    }
}
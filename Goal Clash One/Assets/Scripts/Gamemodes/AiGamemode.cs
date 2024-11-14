public class AiGamemode : GamemodeBase
{
    private AiDirectionInputSystem _inputSystem;

    protected override IDirectionInputSystem ConstructInput()
    {
        _inputSystem = FindObjectOfType<AiDirectionInputSystem>();
        return _inputSystem;
    }

    protected override void Postprocess(PlayerModel[] players)
    {
        FindObjectOfType<AiPlayer>().Initialize(players, _inputSystem);
    }
}
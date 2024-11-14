public class TwoPlayersMode : GamemodeBase
{
    protected override IDirectionInputSystem ConstructInput()
    {
        return FindObjectOfType<SignatureMarcup_AponentInputSystem>().GetComponent<IDirectionInputSystem>();
    }
}
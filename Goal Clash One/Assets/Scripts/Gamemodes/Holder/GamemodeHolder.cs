using UnityEngine;

public class GamemodeHolder
{
    private GamemodeBase _gamemode;
    private GamemodesHolderScriptableObject _holder;

    public GamemodeBase Gamemode => _gamemode;
    public GamemodeBase[] Gamemodes => _holder.Gamemodes;

    public GamemodeHolder(GamemodesHolderScriptableObject holder)
    {
        _holder = holder;
        SetGamemode(_holder.Gamemodes[0]);
    }

    public void SetGamemode(GamemodeBase gamemode)
    {
        _gamemode = gamemode;
    }
}
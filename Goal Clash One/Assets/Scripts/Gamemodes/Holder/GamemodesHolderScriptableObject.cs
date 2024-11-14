using UnityEngine;

[CreateAssetMenu(fileName = "GamemodesHolder", menuName = "Game design/Game/GamemodesHolder")]
public class GamemodesHolderScriptableObject : ScriptableObject
{
    [SerializeField] private GamemodeBase[] _gamemodes;

    public GamemodeBase[] Gamemodes => _gamemodes;
}
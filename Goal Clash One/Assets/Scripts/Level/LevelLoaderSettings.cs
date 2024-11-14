using UnityEngine;

[CreateAssetMenu(fileName = "LevelsLoaderSettings", menuName = "Game design/Game/LevelsLoader")]
public class LevelLoaderSettings : ScriptableObject
{
    [SerializeField][Min(0)] private int _mainMenuSceneIndex = 0;
    [SerializeField][Min(1)] private int _gameplaySceneIndex = 1;

    public int MainMenuSceneIndex => _mainMenuSceneIndex;
    public int GameplaySceneIndex => _gameplaySceneIndex;
}
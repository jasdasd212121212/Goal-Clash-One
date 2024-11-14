using UnityEngine.SceneManagement;

public class LevelsLoader
{
    private LevelLoaderSettings _settings;

    public LevelsLoader(LevelLoaderSettings settings)
    {
        _settings = settings;
    }

    public void StartGameplay()
    {
        LoadLevel(_settings.GameplaySceneIndex);
    }

    public void LoadMainMenu()
    {
        LoadLevel(_settings.MainMenuSceneIndex);
    }

    private void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
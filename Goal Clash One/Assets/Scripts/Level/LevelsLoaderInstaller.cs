using UnityEngine;
using Zenject;

public class LevelsLoaderInstaller : MonoInstaller
{
    [SerializeField] private LevelLoaderSettings _settings;

    public override void InstallBindings()
    {
        Container.Bind<LevelsLoader>().FromInstance(new LevelsLoader(_settings)).AsSingle().Lazy();
    }
}
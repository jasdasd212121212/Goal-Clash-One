using UnityEngine;
using Zenject;

public class TeamsScoreHandlerInstaller : MonoInstaller
{
    [SerializeField] private TeamScoreHandlerSettings _settings;

    public override void InstallBindings()
    {
        Container.Bind<TeamsScoreHandler>().FromInstance(new TeamsScoreHandler(_settings)).AsSingle().NonLazy();
    }
}
using UnityEngine;
using Zenject;

public class GameStateMachineInstaller : MonoInstaller
{
    [SerializeField] private GameStateMachineSettings _settings;

    [Inject] private TeamsScoreHandler _teamsScoreHandler;

    public override void InstallBindings()
    {
        Container.Bind<GameStateMachine>().FromInstance(new GameStateMachine(_settings.ResetingStateDelay, _teamsScoreHandler)).AsSingle().NonLazy();
    }
}
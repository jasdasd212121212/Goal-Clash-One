using UnityEngine;
using Zenject;

public class GamemodeHolderInstaller : MonoInstaller
{
    [SerializeField] private GamemodesHolderScriptableObject _gamemodesHolder;

    public override void InstallBindings()
    {
        Container.Bind<GamemodeHolder>().FromInstance(new GamemodeHolder(_gamemodesHolder)).AsSingle().NonLazy();
    }
}
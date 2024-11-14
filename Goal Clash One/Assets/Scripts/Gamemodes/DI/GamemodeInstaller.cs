using UnityEngine;
using Zenject;

public class GamemodeInstaller : MonoInstaller
{
    [SerializeField] private Transform[] _playerSpawnPoints;

    [Inject] private GamemodeHolder _gamemodesHolder;
    [Inject] private DirectionInputSystemContainer _directionInputSystemContainer;

    public override void InstallBindings()
    {
        _gamemodesHolder.Gamemode.Construct(_playerSpawnPoints, _directionInputSystemContainer);
    }
}
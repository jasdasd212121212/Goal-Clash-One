using UnityEngine;

public abstract class GamemodeBase : MonoBehaviour
{
    [SerializeField] private PlayerModel _playerPrefab;

    private MonoFactory<PlayerModel> _playerFactory;

    public void Construct(Transform[] spawnPoints, DirectionInputSystemContainer container)
    {
        _playerFactory = new MonoFactory<PlayerModel>(_playerPrefab);

        container.SetSystem(ConstructInput());
        PlayerModel[] players = new PlayerModel[spawnPoints.Length];

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            players[i] = _playerFactory.Create(spawnPoints[i].position, Quaternion.identity);
        }

        Postprocess(players);
    }

    protected abstract IDirectionInputSystem ConstructInput();
    protected virtual void Postprocess(PlayerModel[] players) { }
}
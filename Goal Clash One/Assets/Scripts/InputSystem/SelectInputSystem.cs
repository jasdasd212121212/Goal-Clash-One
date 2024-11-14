using UnityEngine;

public class SelectInputSystem : MonoBehaviour
{
    [SerializeField] private Team _team;

    private PlayerModel _currentPlayer;

    public PlayerModel CurrentPlayer => _currentPlayer;

    private void Awake()
    {
        foreach (PlayerModel player in _team.Players)
        {
            player.GetComponent<IPlayerSelectable>().selected += OnSelectPlayer;
        }

        _currentPlayer = _team.Players[0];
    }

    private void OnSelectPlayer(PlayerModel player)
    {
        _currentPlayer = player;
    }
}
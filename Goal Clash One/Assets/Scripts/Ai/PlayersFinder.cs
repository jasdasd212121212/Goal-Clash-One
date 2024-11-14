using System.Linq;
using UnityEngine;

public class PlayersFinder
{
    private Transform[] _players;
    private PlayerAiSeletable[] _playerModels;

    private Transform _ball;

    public PlayersFinder(PlayerModel[] players)
    {
        _playerModels = players.Select(player => player.gameObject.GetComponent<PlayerAiSeletable>()).ToArray();
        _players = players.Select(player => player.transform).ToArray();

        _ball = GameObject.FindObjectOfType<Ball>().transform;
    }

    public PlayerAiSeletable FindNearestPlayer(out Vector3 ballPosition, out Vector3 playerPosition)
    {
        float distanceToNearest = float.MaxValue;
        int nearestIndex = 0;

        for (int i = 0; i < _players.Length; i++)
        {
            float distance = Vector3.Distance(_ball.position, _players[i].position);

            if (distance < distanceToNearest)
            {
                distanceToNearest = distance;
                nearestIndex = i;
            }
        }

        ballPosition = _ball.position;
        playerPosition = _players[nearestIndex].position;

        return _playerModels[nearestIndex];
    }
}
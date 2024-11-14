using System.Linq;
using UnityEngine;
using System;

public class Team : MonoBehaviour
{
    [SerializeField] private TeamType _teamType;
    [SerializeField] private string _teamName;
    [SerializeField] private Color _color;

    private PlayerModel[] _players;
    private int _score;

    public PlayerModel[] Players => _players;
    public int Score => _score;
    public string Name => _teamName;
    public Color Color => _color;

    public event Action scoreChanged;

    private void Awake()
    {
        if (_teamType == TeamType.Red)
        {
            _players = FindObjectsOfType<SignatureMarcup_RedPlayer>().Select(player => player.GetComponent<PlayerModel>()).ToArray();
        }
        else if (_teamType == TeamType.Blue)
        {
            _players = FindObjectsOfType<SignatureMarcup_BluePlayer>().Select(player => player.GetComponent<PlayerModel>()).ToArray();
        }
        else
        {
            Debug.LogError($"Critical error -> undifind team type");
        }
    }

    private void Start()
    {
        Awake();
    }

    public void IncremetnScore()
    {
        _score++;
        scoreChanged?.Invoke();
    }
}
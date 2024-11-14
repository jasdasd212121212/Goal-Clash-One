using UnityEngine;
using Zenject;

public class GameScreensView : MonoBehaviour
{
    [SerializeField] private GameObject _results;

    [Inject] private GameStateMachine _game;

    private void Awake()
    {
        _game.StateMachine.GetState<ResultState>().entered += OnResult;
    }

    private void OnDestroy()
    {
        _game.StateMachine.GetState<ResultState>().entered -= OnResult;
    }

    private void OnResult()
    {
        _results.SetActive(true);
    }
}
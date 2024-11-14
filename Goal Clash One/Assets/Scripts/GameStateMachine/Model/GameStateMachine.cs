using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class GameStateMachine
{
    private PlayingState _playState;
    private ResetingState _resetState;
    private ResultState _resultState;

    private StateMachine _stateMachine;
    private TeamsScoreHandler _scoreHandler;

    private float _resetingDelay;
    private Gates[] _gates;

    public IReadOnlyStateMachine StateMachine => _stateMachine;

    public event Action goal;

    public GameStateMachine(float resetingDelay, TeamsScoreHandler scoreHandler)
    {
        _playState = new PlayingState();
        _resetState = new ResetingState(GameObject.FindObjectsOfType<PlayerModel>(), GameObject.FindObjectOfType<Ball>());
        _resultState = new ResultState();

        _stateMachine = new StateMachine(_playState, _resetState, _resultState);

        _resetingDelay = resetingDelay;
        _scoreHandler = scoreHandler;
        _gates = GameObject.FindObjectsOfType<Gates>();

        foreach (Gates gate in _gates)
        {
            gate.goal += OnGoal;
        }

        _scoreHandler.winCallback += OnWin;
    }

    ~GameStateMachine()
    {
        foreach (Gates gate in _gates)
        {
            gate.goal -= OnGoal;
        }
    }

    private void OnGoal()
    {
        goal?.Invoke();
        Reset().Forget();
    }

    private void OnWin()
    {
        Result().Forget();
    }

    private async UniTask Reset()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_resetingDelay));
        _stateMachine.ChangeState(_resetState);
        _stateMachine.ChangeState(_playState);
    }

    private async UniTask Result()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_resetingDelay));
        _stateMachine.ChangeState(_resultState);
    }
}
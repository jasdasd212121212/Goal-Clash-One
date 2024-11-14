using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

public class AiPlayer : MonoBehaviour
{
    [SerializeField] private AiSettings _settings;

    private PlayersFinder _finder;
    private AiDirectionInputSystem _inputSystem;

    private CancellationTokenSource _cancellationToken;

    private bool _isInitialized;

    public void Initialize(PlayerModel[] players, AiDirectionInputSystem directionInput)
    {
        if (_isInitialized == true)
        {
            return;
        }

        _finder = new PlayersFinder(players);
        _inputSystem = directionInput;
        _cancellationToken = new CancellationTokenSource();

        UpdateLoop().Forget();

        _isInitialized = true;
    }

    private void OnDestroy()
    {
        if (_isInitialized == false)
        {
            return;    
        }

        _cancellationToken.Cancel();
    }

    private async UniTask UpdateLoop()
    {
        while (true)
        {
            _finder.FindNearestPlayer(out Vector3 ball, out Vector3 player).SetSelected();
            _inputSystem.Strike(player, ball);

            await UniTask.Delay(TimeSpan.FromSeconds(_settings.UpdateDelay), cancellationToken: _cancellationToken.Token);
        }
    }
}
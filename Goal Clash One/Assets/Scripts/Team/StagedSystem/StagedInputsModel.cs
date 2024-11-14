using System;
using UnityEngine;
using Zenject;

public class StagedInputsModel : MonoBehaviour
{
    [Inject] private DirectionInputSystemContainer _inputsContainer;

    private int _currentIndex;

    public int CurrentIndex => _currentIndex;

    public event Action<int> changed;

    private void Awake()
    {
        DisableAll();
        _inputsContainer.DirectionInputSystems[0].SetActive(true);

        foreach (IDirectionInputSystem input in _inputsContainer.DirectionInputSystems)
        {
            input.handlerReleased += Swap;
        }
    }

    private void OnDestroy()
    {
        foreach (IDirectionInputSystem input in _inputsContainer.DirectionInputSystems)
        {
            input.handlerReleased -= Swap;
        }
    }

    private void Swap()
    {
        DisableAll();

        _currentIndex++;

        if (_currentIndex >= _inputsContainer.DirectionInputSystems.Length)
        {
            _currentIndex = 0;
        }

        _inputsContainer.DirectionInputSystems[_currentIndex].SetActive(true);

        changed?.Invoke(_currentIndex);
    }

    private void DisableAll()
    {
        foreach (IDirectionInputSystem directionalInputSystem in _inputsContainer.DirectionInputSystems)
        {
            directionalInputSystem.SetActive(false);
        }
    }
}
using System;
using UnityEngine;

public class AiDirectionInputSystem : MonoBehaviour, IDirectionInputSystem
{
    private Vector2 _currentVector;
    private bool _isActive = true;

    public Vector2 CurrentVector => _currentVector;

    public event Action handlerDown;
    public event Action<Vector2> vectorChanged;
    public event Action handlerReleased;

    public void Strike(Vector3 current, Vector3 target)
    {
        if (_isActive == false)
        {
            return;
        }

        _currentVector = target - current;
        handlerReleased?.Invoke();
    }

    public void SetActive(bool isActive)
    {
        _isActive = isActive;
    }
}
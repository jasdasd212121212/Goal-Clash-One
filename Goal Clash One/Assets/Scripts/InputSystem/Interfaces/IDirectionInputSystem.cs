using System;
using UnityEngine;

public interface IDirectionInputSystem
{
    Vector2 CurrentVector { get; }

    event Action handlerDown;
    event Action<Vector2> vectorChanged;
    event Action handlerReleased;

    void SetActive(bool isActive);
}
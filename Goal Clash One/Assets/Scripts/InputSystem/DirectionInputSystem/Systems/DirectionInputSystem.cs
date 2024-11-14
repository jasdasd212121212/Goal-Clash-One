using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DirectionInputSystem : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IDirectionInputSystem
{
    [SerializeField] private float _distanceTranshold;

    private bool _enabled = true;

    private Vector2 _startPoint;
    private Vector2 _currentVector;

    public Vector2 CurrentVector => _currentVector;

    public event Action handlerDown;
    public event Action<Vector2> vectorChanged;
    public event Action handlerReleased;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_enabled == false)
        {
            return;
        }

        _startPoint = eventData.position;
        handlerDown?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_enabled == false)
        {
            return;
        }

        if (Vector2.Distance(eventData.position, _startPoint) >= _distanceTranshold)
        {
            _currentVector = _startPoint - eventData.position;
            vectorChanged?.Invoke(_currentVector);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_enabled == false)
        {
            return;
        }

        handlerReleased?.Invoke();
        _currentVector = Vector2.zero;
    }

    public void SetActive(bool isActive)
    {
        _enabled = isActive;
    }
}
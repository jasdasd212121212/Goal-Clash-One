using System;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public class PlayerSelectionHandler : MonoBehaviour, IPlayerSelectable
{
    private PlayerModel _player;

    public event Action<PlayerModel> selected;

    private void Awake()
    {
        _player = GetComponent<PlayerModel>();
    }

    private void OnMouseDown()
    {
        selected?.Invoke(_player);
    }
}
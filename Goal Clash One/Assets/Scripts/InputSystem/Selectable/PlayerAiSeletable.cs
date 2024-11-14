using System;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public class PlayerAiSeletable : MonoBehaviour, IPlayerSelectable
{
    private PlayerModel _model;

    public event Action<PlayerModel> selected;

    private void Awake()
    {
        _model = GetComponent<PlayerModel>();
    }

    public void SetSelected()
    {
        selected?.Invoke(_model);
    }
}
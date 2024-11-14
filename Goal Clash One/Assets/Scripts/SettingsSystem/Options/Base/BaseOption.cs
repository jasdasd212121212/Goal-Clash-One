using System;
using UnityEngine;

public abstract class BaseOption : MonoBehaviour, IOption
{
    public event Action changed;

    public void Initialize()
    {
        OnLoad();
    }

    public void SaveSettings()
    {
        OnSave();
    }

    protected abstract void OnLoad();
    protected abstract void OnSave();

    protected void CallChanged()
    {
        changed?.Invoke();
    }
}
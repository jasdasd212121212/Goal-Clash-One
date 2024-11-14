using UnityEngine;
using UnityEngine.UI;

public abstract class ToggleOptionBase : BaseOption
{
    [SerializeField] private Toggle _toggle;

    protected override void OnLoad()
    {
        if (PlayerPrefs.HasKey(GetKey()) == false)
        {
            _toggle.isOn = true;
        }
        else
        {
            _toggle.isOn = PlayerPrefsExtanded.GetBool(GetKey());
        }

        _toggle.onValueChanged.AddListener(OnChangeToggle);

        OnLoaded();
        OnChangedState(_toggle.isOn);
    }

    protected override void OnSave()
    {
        PlayerPrefsExtanded.SetBool(GetKey(), _toggle.isOn);
    }

    protected abstract string GetKey();
    protected abstract void OnLoaded();
    protected abstract void OnChangedState(bool state);

    protected void OnChangeToggle(bool value)
    {
        OnChangedState(value);
        CallChanged();
    }
}
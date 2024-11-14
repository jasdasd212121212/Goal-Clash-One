using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(GamemodeSelectedButtonLightuperView))]
public class GamemodeButtonView : MonoBehaviour
{
    private Button _button;
    private GamemodesPresenter _presenter;

    private int _index;
    private bool _initialized;

    public event Action<GamemodeButtonView> clicked;

    public void Initialize(int index, GamemodesPresenter presenter)
    {
        if (_initialized == true)
        {
            return;
        }

        _button = GetComponent<Button>();
        _presenter = presenter;

        _index = index;
        _button.onClick.AddListener(OnClick);

        _initialized = true;
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OnClick()
    {
        _presenter.SetGamemode(_index);
        clicked?.Invoke(this);
    }
}
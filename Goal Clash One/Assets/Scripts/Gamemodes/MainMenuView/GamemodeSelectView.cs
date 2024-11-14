using UnityEngine;

public class GamemodeSelectView : MonoBehaviour
{
    [SerializeField] private GamemodesPresenter _presenter;
    [SerializeField] private GamemodeButtonView[] _buttons;

    private void Awake()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].Initialize(i, _presenter);
            _buttons[i].clicked += OnSelect;
        }
    }

    private void OnDestroy()
    {
        foreach (GamemodeButtonView button in _buttons)
        {
            button.clicked -= OnSelect;
        }
    }

    private void OnSelect(GamemodeButtonView button)
    {
        DeselectAll();
        button.GetComponent<GamemodeSelectedButtonLightuperView>().SetOutlineActive(true);
    }

    private void DeselectAll()
    {
        foreach (GamemodeButtonView button in _buttons)
        {
            button.GetComponent<GamemodeSelectedButtonLightuperView>().SetOutlineActive(false);
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class StagedInputsViewPlate : MonoBehaviour
{
    [SerializeField] private Color _inactiveColor;
    [SerializeField] private Color _activeColor;

    private SpriteRenderer _image;

    private bool _initialized;
    private int _index;

    public void Initialize(int index)
    {
        if (_initialized == true)
        {
            return;
        }

        if (index < 0)
        {
            Debug.Log($"Critical error -> can`t set index < 0");
            return;
        }

        _index = index;
        _image = GetComponent<SpriteRenderer>();

        _initialized = true;
    }

    public void Show(int index)
    {
        _image.color = index == _index ? _inactiveColor : _activeColor;
    }
}
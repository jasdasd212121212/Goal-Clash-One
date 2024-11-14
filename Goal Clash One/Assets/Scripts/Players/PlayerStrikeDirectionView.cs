using UnityEngine;
using Zenject;

public class PlayerStrikeDirectionView : MonoBehaviour
{
    [SerializeField] private int _directionInputSystemIndex;
    [SerializeField] private SelectInputSystem _selectInputSystem;

    [Space]

    [SerializeField] private Transform _arrow;

    [Inject] private DirectionInputSystemContainer _directionInputSystemContainer;

    private IDirectionInputSystem _directionInputSystem;

    private void Awake()
    {
        _directionInputSystem = _directionInputSystemContainer.DirectionInputSystems[_directionInputSystemIndex];

        _directionInputSystem.vectorChanged += DrawVector;
        _directionInputSystem.handlerReleased += HideVector;
    }

    private void OnDestroy()
    {
        _directionInputSystem.vectorChanged -= DrawVector;
        _directionInputSystem.handlerReleased -= HideVector;
    }

    public void SetInputSystem(IDirectionInputSystem inputSystem)
    {
        _directionInputSystem = inputSystem;
    }

    private void DrawVector(Vector2 direction)
    {
        _arrow.gameObject.SetActive(true);

        float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        _arrow.rotation = Quaternion.Euler(0f, 0f, angle);
        _arrow.position = _selectInputSystem.CurrentPlayer.transform.position;
    }

    private void HideVector()
    {
        _arrow.gameObject.SetActive(false);
    }
}
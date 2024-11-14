using UnityEngine;
using Zenject;

public class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private int _directionInputSystemIndex;
    [SerializeField] private SelectInputSystem _selectInputSystem;

    [Inject] private DirectionInputSystemContainer _directionInputSystemContainer;

    private IDirectionInputSystem _directionInputSystem;

    private void Awake()
    {
        _directionInputSystem = _directionInputSystemContainer.DirectionInputSystems[_directionInputSystemIndex];

        _directionInputSystem.handlerReleased += OnRelease;
    }

    private void OnDestroy()
    {
        _directionInputSystem.handlerReleased -= OnRelease;
    }

    public void SetInputSystem(IDirectionInputSystem inputSystem)
    {
        _directionInputSystem = inputSystem;
    }

    private void OnRelease()
    {
        _selectInputSystem.CurrentPlayer.ApplyDirection(_directionInputSystem.CurrentVector);
    }
}
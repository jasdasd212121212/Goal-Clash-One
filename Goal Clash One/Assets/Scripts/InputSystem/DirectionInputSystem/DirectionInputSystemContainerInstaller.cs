using UnityEngine;
using Zenject;

public class DirectionInputSystemContainerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _directionInputSystemObject;

    private IDirectionInputSystem _directionInputSystem;

    private void OnValidate()
    {
        if (_directionInputSystemObject != null && _directionInputSystemObject.GetComponent<IDirectionInputSystem>() == null)
        {
            Debug.LogError($"Ciritical error -> can`t set an object are not exist any script realises {nameof(IDirectionInputSystem)} interface");
            _directionInputSystemObject = null;
        }
    }

    public override void InstallBindings()
    {
        _directionInputSystem = _directionInputSystemObject.GetComponent<IDirectionInputSystem>();

        DirectionInputSystemContainer container = new DirectionInputSystemContainer();
        Container.Bind<DirectionInputSystemContainer>().FromInstance(container).AsSingle().NonLazy();

        container.SetSystem(_directionInputSystem);
    }
}
using System.Collections.Generic;

public class DirectionInputSystemContainer
{
    private List<IDirectionInputSystem> _directionInputSystem = new List<IDirectionInputSystem>();

    public IDirectionInputSystem[] DirectionInputSystems => _directionInputSystem.ToArray();

    public void SetSystem(IDirectionInputSystem directionInputSystem)
    {
        _directionInputSystem.Add(directionInputSystem);
    }
}
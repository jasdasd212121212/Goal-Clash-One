using UnityEngine;
using Zenject;

[RequireComponent(typeof(StagedInputsModel))]
public class StagedInputsView : MonoBehaviour
{
    [Inject] private DirectionInputSystemContainer _inputs;

    private StagedInputsModel _model;
    private StagedInputsViewPlate[] _plates;

    private void Awake()
    {
        _model = GetComponent<StagedInputsModel>();
        _plates = FindObjectsOfType<StagedInputsViewPlate>();
    
        InitializePlates();

        _model.changed += OnModelChanged;
        OnModelChanged(_model.CurrentIndex);
    }

    private void OnDestroy()
    {
        _model.changed -= OnModelChanged;
    }

    private void OnModelChanged(int currentIndex)
    {
        foreach (StagedInputsViewPlate plate in _plates)
        {
            plate.Show(currentIndex);
        }
    }

    private void InitializePlates()
    {
        for (int i = 0; i < _inputs.DirectionInputSystems.Length; i++)
        {
            _plates[i].Initialize(i);
        }
    }
}
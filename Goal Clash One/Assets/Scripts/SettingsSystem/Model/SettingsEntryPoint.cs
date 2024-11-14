using UnityEngine;

public class SettingsEntryPoint : MonoBehaviour
{
    [SerializeField] protected BaseOption[] _options;

    private SettingsModel _model;

    private void Start()
    {
        _model = new SettingsModel(_options);
    }

    private void OnDestroy()
    {
        _model.Dispose();
    }
}
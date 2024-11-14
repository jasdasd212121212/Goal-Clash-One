using System;

public class SettingsModel : IDisposable
{
    protected BaseOption[] _options;

    public SettingsModel(BaseOption[] options) 
    {
        _options = options;

        foreach (BaseOption option in _options)
        {
            option.Initialize();
            option.changed += SaveSettings;
        }
    }

    public void Dispose()
    {
        foreach (BaseOption option in _options)
        {
            option.changed -= SaveSettings;
        }
    }

    protected void SaveSettings()
    {
        foreach (BaseOption option in _options)
        {
            option.SaveSettings();
        }
    }
}
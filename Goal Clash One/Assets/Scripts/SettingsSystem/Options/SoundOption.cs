using UnityEngine;
using UnityEngine.Audio;

public class SoundOption : ToggleOptionBase
{
    [SerializeField] protected AudioMixer _mixer;
    [SerializeField] private float _defaultVolume = 0f;

    private SoundGroupStateMachine _soundsStateMachine;

    protected override void OnLoaded()
    {
        _soundsStateMachine = new SoundGroupStateMachine(_mixer, "Sounds", _defaultVolume);
    }

    protected override void OnChangedState(bool state)
    {
        _soundsStateMachine.SetActive(state);
    }

    protected override string GetKey()
    {
        return SavingConfig.SOUNDS_ENABLED;
    }
}
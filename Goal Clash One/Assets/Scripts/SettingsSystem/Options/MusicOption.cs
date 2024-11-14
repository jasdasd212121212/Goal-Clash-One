using UnityEngine;
using UnityEngine.Audio;

public class MusicOption : ToggleOptionBase
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private float _defaultVolume = 0f;

    private SoundGroupStateMachine _soundsStateMachine;

    protected override void OnLoaded()
    {
        _soundsStateMachine = new SoundGroupStateMachine(_mixer, "Music", _defaultVolume);
    }

    protected override void OnChangedState(bool state)
    {
        _soundsStateMachine.SetActive(state);
    }

    protected override string GetKey()
    {
        return SavingConfig.MUSIC_ENABLED;
    }
}
using UnityEngine.Audio;

public class SoundGroupStateMachine
{
    private DisabledSoundGorupState _disabled;
    private EnabledSoundGorupState _enabled;

    private StateMachine _stateMachine;

    public SoundGroupStateMachine(AudioMixer mixer, string groupName, float defaultEnabledDecebells)
    {
        _disabled = new DisabledSoundGorupState(mixer, groupName);
        _enabled = new EnabledSoundGorupState(mixer, groupName, defaultEnabledDecebells);

        _stateMachine = new StateMachine(_enabled, _disabled);
    }

    public void SetActive(bool state)
    {
        if (state == true)
        {
            _stateMachine.ChangeState(_enabled);
        }
        else
        {
            _stateMachine.ChangeState(_disabled);
        }
    }
}
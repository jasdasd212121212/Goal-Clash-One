using UnityEngine.Audio;

public class EnabledSoundGorupState : State
{
    private AudioMixer _mixer;
    private string _groupName;

    private float _defaultDecebells;

    public EnabledSoundGorupState(AudioMixer mixer, string groupName, float defaultDecebells)
    {
        _mixer = mixer;
        _groupName = groupName;
        _defaultDecebells = defaultDecebells;
    }

    public override void OnEnter()
    {
        _mixer.SetFloat(_groupName, _defaultDecebells);
    }
}
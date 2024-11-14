using UnityEngine.Audio;

public class DisabledSoundGorupState : State
{
    private AudioMixer _mixer;
    private string _groupName;

    public DisabledSoundGorupState(AudioMixer mixer, string groupName)
    {
        _mixer = mixer;
        _groupName = groupName;
    }

    public override void OnEnter()
    {
        _mixer.SetFloat(_groupName, -80f);
    }
}
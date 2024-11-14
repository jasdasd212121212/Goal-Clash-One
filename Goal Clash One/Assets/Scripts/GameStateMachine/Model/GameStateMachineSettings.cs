using UnityEngine;

[CreateAssetMenu(fileName = "GameStateMachineSettings", menuName = "Game design/Game/StateMachineSettins")]
public class GameStateMachineSettings : ScriptableObject
{
    [SerializeField] private float _resetingStateDelay = 1.5f;

    public float ResetingStateDelay => _resetingStateDelay;
}
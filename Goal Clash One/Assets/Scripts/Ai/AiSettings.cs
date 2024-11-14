using UnityEngine;

[CreateAssetMenu(fileName = "AiSettings", menuName = "Game design/Ai/Settings")]
public class AiSettings : ScriptableObject
{
    [SerializeField][Min(0.1f)] private float _updateDelay = 3f;

    public float UpdateDelay => _updateDelay;
}
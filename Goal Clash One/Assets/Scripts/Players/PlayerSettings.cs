using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Game design/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField][Min(0.001f)] private float _impulse;
    [SerializeField][Min(0.001f)] private float _minVelocityMagnitudeToCountCollision = 4f;

    public float Impulse => _impulse;
    public float MinVelocityMagnitudeToCountCollision => _minVelocityMagnitudeToCountCollision;
}
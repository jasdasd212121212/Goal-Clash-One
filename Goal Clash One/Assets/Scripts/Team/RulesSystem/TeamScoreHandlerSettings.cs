using UnityEngine;

[CreateAssetMenu(fileName = "Rules", menuName = "Game design/Game/Rules")]
public class TeamScoreHandlerSettings : ScriptableObject
{
    [SerializeField][Min(1)] private int _goalsToWin = 5;

    public int GoalsToWin => _goalsToWin;
}
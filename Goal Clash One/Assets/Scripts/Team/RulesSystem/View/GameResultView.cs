using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;
using System.Text;

public class GameResultView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _commandName;
    [SerializeField] private TextMeshProUGUI _scores;
    [SerializeField] private Image _teamIcon;

    [Inject] private TeamsScoreHandler _scoreHandler;

    [Inject]
    private void Construct()
    {
        _scoreHandler.win += Display;
    }

    private void OnDestroy()
    {
        _scoreHandler.win -= Display;
    }

    private void Display(Team winner, Team[] teams)
    {
        _teamIcon.color = winner.Color;
        _commandName.text = winner.Name + " wins!";

        StringBuilder scoresBuilder = new StringBuilder();

        foreach (Team team in teams)
        {
            scoresBuilder.Append($"<color={RGB2HEX(team.Color)}>{team.Score}</color>:");
        }

        scoresBuilder.Remove(scoresBuilder.Length - 1, 1);

        _scores.text = scoresBuilder.ToString();
    }

    private string RGB2HEX(Color color)
    {
        return $"#{ColorUtility.ToHtmlStringRGBA(color)}";
    }
}
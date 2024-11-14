using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private Team _targetTeam;

    private TextMeshProUGUI _targetText;

    private void Awake()
    {
        _targetText = GetComponent<TextMeshProUGUI>();
        _targetTeam.scoreChanged += OnScoreChanged;

        OnScoreChanged();
    }

    private void OnDestroy()
    {
        _targetTeam.scoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        Display(_targetTeam.Score);
    }

    private void Display(int score)
    {
        _targetText.text = score.ToString();
    }
}
using System;
using System.Linq;
using UnityEngine;

public class TeamsScoreHandler
{
    private TeamScoreHandlerSettings _settings;
    private Team[] _teams;

    public event Action<Team, Team[]> win;
    public event Action winCallback;

    public TeamsScoreHandler(TeamScoreHandlerSettings settings)
    {
        _settings = settings;
        _teams = GameObject.FindObjectsOfType<Team>();

        foreach (Team team in _teams)
        {
            team.scoreChanged += Handle;
        }
    }

    ~TeamsScoreHandler()
    {
        foreach (Team team in _teams)
        {
            team.scoreChanged -= Handle;
        }
    }

    private void Handle()
    {
        foreach(Team team in _teams)
        {
            if (team.Score >= _settings.GoalsToWin)
            {
                win?.Invoke(team, _teams);
                winCallback?.Invoke();
            }
        }
    }
}
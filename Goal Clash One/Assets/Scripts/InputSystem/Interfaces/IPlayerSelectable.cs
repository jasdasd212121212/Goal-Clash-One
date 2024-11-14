using System;

public interface IPlayerSelectable
{
    event Action<PlayerModel> selected;
}
using UnityEngine;
using Zenject;

public class GamemodesPresenter : MonoBehaviour
{
    [Inject] private GamemodeHolder _holder;
    
    public void SetGamemode(int index)
    {
        if (index < 0 || index > (_holder.Gamemodes.Length - 1))
        {
            Debug.LogError($"Critical error -> can`t choose game mode by index: {index} because index outside of bounds; Bound: (0, {_holder.Gamemodes.Length - 1})");
            return;
        }

        _holder.SetGamemode(_holder.Gamemodes[index]);
    }
}
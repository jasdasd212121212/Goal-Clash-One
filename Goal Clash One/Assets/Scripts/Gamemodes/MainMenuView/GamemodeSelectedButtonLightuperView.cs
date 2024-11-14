using UnityEngine;

public class GamemodeSelectedButtonLightuperView : MonoBehaviour
{
    [SerializeField] private GameObject _outline;

    public void SetOutlineActive(bool state)
    {
        _outline.SetActive(state);
    }
}
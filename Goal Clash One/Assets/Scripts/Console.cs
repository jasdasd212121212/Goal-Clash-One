using TMPro;
using UnityEngine;
using Zenject;

public class Console : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [Inject]
    private void Construct()
    {
        Application.logMessageReceived += OnMessage;
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= OnMessage;
    }

    private void OnMessage(string condition, string stackTrace, LogType type)
    {
        _text.text += type == LogType.Error ? $"<color=red>{condition}\n {stackTrace}\n\n</color>" : condition + "\n";
    }
}
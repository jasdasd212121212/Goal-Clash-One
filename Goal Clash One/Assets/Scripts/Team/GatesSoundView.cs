using UnityEngine;

[RequireComponent(typeof(Gates))]
public class GatesSoundView : MonoBehaviour
{
    [SerializeField] private AudioSource _goalSound;

    private Gates _model;

    private void Awake()
    {
        _model = GetComponent<Gates>();
        _model.goal += OnGoal;
    }

    private void OnDestroy()
    {
        _model.goal -= OnGoal;
    }

    private void OnGoal()
    {
        _goalSound.Play();
    }
}
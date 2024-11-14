using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public class PlayerSoundView : MonoBehaviour
{
    [SerializeField] private AudioSource _collideSound;

    private PlayerModel _model;

    private void Awake()
    {
        _model = GetComponent<PlayerModel>();
        _model.collided += OnCollided;
    }

    private void OnDestroy()
    {
        _model.collided -= OnCollided;
    }

    private void OnCollided()
    {
        _collideSound.Play();   
    }
}
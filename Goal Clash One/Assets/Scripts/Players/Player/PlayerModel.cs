using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModel : MonoBehaviour
{
    [SerializeField] private PlayerSettings _settings;

    private Rigidbody2D _rigidbody;
    private Vector3 _startPoint;

    public event Action collided;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPoint = transform.position;
    }

    public void ApplyDirection(Vector2 direction)
    {
        _rigidbody.AddForce(direction.normalized * _settings.Impulse, ForceMode2D.Force);
    }

    public void ResetPosition()
    {
        transform.position = _startPoint;

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(_rigidbody.velocity.magnitude) >= _settings.MinVelocityMagnitudeToCountCollision )
        {
            collided?.Invoke();
        }
    }
}
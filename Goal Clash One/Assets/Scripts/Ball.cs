using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Vector3 _startPoint;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _startPoint = transform.position;
    
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        transform.position = _startPoint;

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0f;
    }
}
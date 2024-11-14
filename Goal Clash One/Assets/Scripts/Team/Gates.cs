using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Gates : MonoBehaviour
{
    [SerializeField] private Team _targetTeam;

    public event Action goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            _targetTeam.IncremetnScore();
            goal?.Invoke();

            Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            
            rigidbody.velocity = Vector3.zero;
        }
    }
}
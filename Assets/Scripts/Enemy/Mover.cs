using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rangeToChange = 0.5f;
    
    private float _sqrRange;
    private Transform _waypoint;
    private Rigidbody2D _rigidbody2D;
    
    public event Action IsReached;

    public Vector2 Direction { get; private set; } 
    
    public void Initialize()
    {
        _sqrRange = _rangeToChange * _rangeToChange;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform waypoint)
    {
        _waypoint = waypoint;
    }

    public void Move()
    {
        if (_waypoint == null)
            return;

        Direction = (_waypoint.position - transform.position).normalized;
        _rigidbody2D.linearVelocity = Direction * _speed;

        if ((transform.position - _waypoint.position).sqrMagnitude < _sqrRange)
            IsReached?.Invoke();
    }
}
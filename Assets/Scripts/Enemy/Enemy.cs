using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Route _route;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private EnemyAnimator _animator;

    [Header("Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rangeToChange = 0.5f;

    private Transform _currentWaypoint;
    private Vector2 _moveDirection;
    private float _sqrRange;
    private bool _isMoving;

    private bool IsWaypointReached =>
        (_currentWaypoint.position - transform.position).sqrMagnitude < _sqrRange;

    private void Awake()
    {
        if (_route == null || _mover == null)
            return;

        _route.Initialize();
        _sqrRange = _rangeToChange * _rangeToChange;
        _currentWaypoint = _route.GetWaypoint();
    }

    private void Update()
    {
        if (_currentWaypoint == null)
        {
            StopMoving();
        }
        else if (IsWaypointReached)
        {
            SwitchToNextWaypoint();
        }
        else
        {
            MoveToWaypoint();
        }
    }

    private void SwitchToNextWaypoint() =>
        _currentWaypoint = _route.GetWaypoint();

    private void StopMoving()
    {
        if (_isMoving)
        {
            _isMoving = false;
            _animator.SetIdle();
        }
    }

    private void MoveToWaypoint()
    {
        _moveDirection = (_currentWaypoint.position - transform.position).normalized;
        _isMoving = true;

        _mover.Move(_moveDirection * _speed);
        _rotator.SetDirection(_moveDirection.x);
        _animator.SetMoving();
    }
}
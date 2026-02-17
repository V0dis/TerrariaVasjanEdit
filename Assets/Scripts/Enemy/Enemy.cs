using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Route _route;
    [SerializeField] private DirectionChanger _directionChanger;
    [SerializeField] private EnemyAnimationController _animationController;
    
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rangeToChange = 0.5f;

    private Transform _currentWaypoint;
    private Vector2 _moveDirection;
    private Vector2 _velocity;
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
            if (_isMoving)
            {
                _isMoving = false;
                _animationController.UpdateAnimation(_isMoving);
            }
            return;
        }

        if (IsWaypointReached)
            SwitchToNextWaypoint();

        MoveToWaypoint();
    }

    private void SwitchToNextWaypoint() => 
        _currentWaypoint = _route.GetWaypoint();
    
    private void UpdateAnimation(Vector2 direction)
    {
        if (_directionChanger == null)
            return;

        _directionChanger.SetDirection(direction.x);
        _animationController.UpdateAnimation(_isMoving);
    }

    private void MoveToWaypoint()
    {
        _moveDirection = (_currentWaypoint.position - transform.position).normalized;
        _isMoving = true;

        _velocity = _moveDirection * _speed;
        _mover.Move(_velocity);

        UpdateAnimation(_moveDirection);
    }
}

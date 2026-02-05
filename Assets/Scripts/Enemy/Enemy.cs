using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Route _route;
    [SerializeField] private WaypointsHandler _waypointsHandler;
    [SerializeField] private EnemyAnimation _animation;

    public void Awake()
    {
        _mover.Initialize();
        _route.Initialize(_waypointsHandler.GetWaypoints());
        
        _mover.SetTarget(_route.GetWaypoint());
    }

    private void OnEnable()
    {
        _mover.IsReached += SelectTarget;
    }

    private void Update()
    {
        _mover.Move();
        _animation.SetRun(_mover.Direction.x);
    }

    private void OnDisable()
    {
        _mover.IsReached -= SelectTarget;
    }

    private void SelectTarget()
    {
        _mover.SetTarget(_route.GetWaypoint());
    }
}

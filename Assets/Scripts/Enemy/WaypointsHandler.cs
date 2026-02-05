using System;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsHandler : MonoBehaviour
{
    [SerializeField] public List<Transform> waypoints;

    public List<Transform> GetWaypoints() => new List<Transform>(waypoints);

    private void Start()
    {
        foreach (Transform waypoint in waypoints)
        {
            if (TryGetComponent(out Waypoint waypointComponent) == false)
            {
                waypoint.gameObject.AddComponent<Waypoint>();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    private Queue<Transform> _waypoints = new Queue<Transform>();

    public void Initialize(List<Transform> waypoints)
    {
        RebuildLoopedQueue(waypoints);
    }

    public Transform GetWaypoint()
    {
        Transform waypoint = _waypoints.Peek();
        
        _waypoints.Enqueue(_waypoints.Dequeue());
        
        return waypoint;
    }

    private void RebuildLoopedQueue(List<Transform> originalWaypoints)
    {
        if (originalWaypoints == null || originalWaypoints.Count == 0)
            return;
        
        int nearestIndex = 0;
        float minDistance = Single.MaxValue;

        for (int i = 0; i < originalWaypoints.Count; i++)
        {
            float distance = (originalWaypoints[i].position - transform.position).sqrMagnitude;
            
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestIndex = i;
            }
        }
        
        for (int i = 0; i < originalWaypoints.Count; i++)
        {
            _waypoints.Enqueue(originalWaypoints[(nearestIndex + i) % originalWaypoints.Count]);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidBehavior : SteeringBehavior
{
    [SerializeField, Header("Avoid Set up")] private float maxSeeAhead = 1f;
    [SerializeField] private Obstacles obstacles;
    [SerializeField] private float maxAvoidForce = 2f;
    [SerializeField] private float obstacleRadius = 1f;
    
    private List<Vector3> _obstacleList;
    private Vector3 _ahead, _ahead2, _pos;

    private void Start()
    {
        _obstacleList = obstacles.obstacleList;
    }

    public override Vector3 GetForce()
    {
        _pos = transform.position;
        _ahead = rb.velocity.normalized * maxSeeAhead;
        _ahead2 = _ahead * 0.5f;

        _ahead += _pos;
        _ahead2 += _pos;
        
        // Calculate the Avoidance Force
        Vector3? biggestThreat = FindBiggestThreat();
        Vector3 avoidanceForce = Vector3.zero;

        if (biggestThreat != null)
        {
            avoidanceForce.x = _ahead.x - biggestThreat.Value.x;
            avoidanceForce.z = _ahead.z - biggestThreat.Value.z;
        }
        avoidanceForce = avoidanceForce.normalized * (biggestThreat != null ? maxAvoidForce : 0);
        
        
        // Lines for debug movement
        Debug.DrawLine(_pos, _ahead, Color.red);
        Debug.DrawLine(_pos, _ahead2, Color.black);
        Debug.DrawLine(_pos, _pos + avoidanceForce, Color.cyan);

        return avoidanceForce;
    }

    private Vector3? FindBiggestThreat()
    {
        Vector3? biggestThreat = null;
        foreach (var o in _obstacleList)
        {
            var collision = CollisionDetected(_ahead, _ahead2, o);
            var stuck = biggestThreat.HasValue && Vector3.Distance(_pos, o) < Vector3.Distance(_pos, biggestThreat.Value);
            if (collision && (!biggestThreat.HasValue || stuck))
            {
                biggestThreat = o;
            }
        }
        return biggestThreat;
    }

    private bool CollisionDetected(Vector3 ahead, Vector3 ahead2, Vector3 obstacle)
    {
        bool collAhead = Vector3.Distance(ahead, obstacle) <= obstacleRadius;
        bool collAhead2 = Vector3.Distance(ahead2, obstacle) <= obstacleRadius;
        return collAhead || collAhead2;
    }

}

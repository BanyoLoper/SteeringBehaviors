using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidBehavior : SteeringBehavior
{
    [SerializeField] private float maxSeeAhead = 1f;
    
    
    void Start()
    {
    }

    public override Vector3 GetForce()
    {
        Vector3 ahead = transform.position + rb.velocity.normalized * maxSeeAhead;
        
        
        return Vector3.zero;
    }
    
}

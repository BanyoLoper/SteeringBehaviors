using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WanderBehavior : SteeringBehavior
{
    public float circleDistance = 2f;
    public float circleRadius = 1f;
    public float wanderAngle = 0f;

    private Vector3 displacement = Vector3.zero;

    public override Vector3 GetForce()
    {


        Vector3 wanderForce = Vector3.zero;
        return wanderForce;
    }
}

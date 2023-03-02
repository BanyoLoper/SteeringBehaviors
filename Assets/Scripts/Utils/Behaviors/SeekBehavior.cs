using UnityEngine;

public class SeekBehavior : SteeringBehavior
{
    public override Vector3 GetForce()
    {
        return Vector3.forward;
    }
}

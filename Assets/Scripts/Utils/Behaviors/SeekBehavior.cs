using UnityEngine;

public class SeekBehavior : SteeringBehavior
{
    public Vector3 seekPoint;
    
    public override Vector3 GetForce()
    {
        return Seek(seekPoint);
    }

    public Vector3 Seek(Vector3 target)
    {
        DesiredVelocity = (target - transform.position).normalized * speed;
        return DesiredVelocity - rb.velocity;
    }
    
}

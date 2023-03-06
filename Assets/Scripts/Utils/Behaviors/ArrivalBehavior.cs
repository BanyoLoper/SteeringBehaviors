using UnityEngine;

public class ArrivalBehavior : SteeringBehavior
{
    [SerializeField] private float slowingRadius = 3f;
    private SeekBehavior _seek;
    public Vector3 seekPoint;
    
    
    void Start()
    {
        _seek = gameObject.GetComponent<SeekBehavior>();
    }

    public override Vector3 GetForce()
    {
        return Arrive(seekPoint);
    }

    public Vector3 Arrive(Vector3 target)
    {
        DesiredVelocity = (target - transform.position);
        float distance = DesiredVelocity.magnitude;
        float factor = maxSpeed;
        if (distance < slowingRadius)
        {
            factor = maxSpeed * (distance / slowingRadius);
        }
        
        DesiredVelocity = DesiredVelocity.normalized * (maxSpeed * factor);
        return DesiredVelocity - rb.velocity;
    }
    
}

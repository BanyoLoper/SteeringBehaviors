using System.Collections.Generic;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    public List<SteeringBehavior> behaviors = new List<SteeringBehavior>();
    private Rigidbody _rb;
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        Vector3 totalForce = Vector3.zero;
        foreach (SteeringBehavior behavior in behaviors)
        {
            totalForce += behavior.GetForce();
        }
        
        // todo: Clamp total force
        // totalForce = Vector3.ClampMagnitude(totalForce, );
        
        _rb.AddForce(totalForce, ForceMode.Acceleration);
    }
}

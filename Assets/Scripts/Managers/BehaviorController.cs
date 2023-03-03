using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BehaviorController : MonoBehaviour
{
    public List<SteeringBehavior> behaviors = new List<SteeringBehavior>();
    private Rigidbody _rb;
    private Vector3 _velocity;
    private Vector3 _totalForce = Vector3.zero;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        _totalForce = Vector3.zero;
        foreach (SteeringBehavior behavior in behaviors)
        {
            behavior.rb = _rb;
            _totalForce += behavior.GetForce();
        }
        
        _rb.AddForce(_totalForce, ForceMode.Acceleration);
    }
}

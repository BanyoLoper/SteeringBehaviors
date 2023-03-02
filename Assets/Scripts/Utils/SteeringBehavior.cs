using UnityEngine;

public abstract  class SteeringBehavior : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float maxForce = 5f;
    public Vector3 target;
    
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public abstract Vector3 GetForce();
}

using UnityEngine;

public abstract  class SteeringBehavior : MonoBehaviour
{
    // Fields
    public float maxSpeed = 10f;
    public float maxForce = 5f;
    public float speed = 2f;

    // Properties
    public Vector3 DesiredVelocity { get; set; }
    public Rigidbody rb { get; set;}

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public abstract Vector3 GetForce();
}

using UnityEngine;

public class PursuitBehavior : SteeringBehavior
{
    [SerializeField, Header("Future Frames")]
    private int T = 2;
    
    private SeekBehavior _seek;
    public Transform target;
    public Vector3 targetVelocity;
    private Vector3 _futurePosition;

    void Start()
    {
        _seek = gameObject.GetComponent<SeekBehavior>();
    }

    public override Vector3 GetForce()
    {
        _futurePosition = target.position + targetVelocity * T;
        return _seek.Seek(_futurePosition);
    }
}

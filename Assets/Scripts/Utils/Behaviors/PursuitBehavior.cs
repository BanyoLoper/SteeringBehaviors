using UnityEngine;

public class PursuitBehavior : SteeringBehavior
{
    public GameObject target;
    [SerializeField, Header("Future Frames")]
    private int T = 2;
    
    private SeekBehavior _seek;

    private Vector3 _futurePosition;
    private Rigidbody _targetRb;

    void Start()
    {
        _seek = gameObject.GetComponent<SeekBehavior>();
        _targetRb = target.GetComponent<Rigidbody>();
    }

    public override Vector3 GetForce()
    {
        _futurePosition = target.transform.position + _targetRb.velocity * T;
        return _seek.Seek(_futurePosition);
    }
}

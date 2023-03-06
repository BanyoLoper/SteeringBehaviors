using UnityEngine;

public class PursuitEnemy : SteeringBehavior
{
    [SerializeField, Header("Future Frames")]
    private int T = 2;

    [SerializeField] private string targetName = "Player";

    private SeekBehavior _seek;
    private Transform _player;
    private Vector3 _futurePosition;

    void Start()
    {
        _seek = gameObject.GetComponent<SeekBehavior>();
        _player = GameObject.Find(targetName).transform;
    }

    public override Vector3 GetForce()
    {
        _futurePosition = transform.position + rb.velocity * T;
        return _seek.Seek(_futurePosition);
    }
    
}

using UnityEngine;

public class RunAwayBehavior : SteeringBehavior
{
    [SerializeField] private string targetName = "Player"; 
        
    private SeekBehavior _seek;
    private Transform _player;
    void Start()
    {
        _seek = gameObject.GetComponent<SeekBehavior>();
        _player = GameObject.Find(targetName).transform;
    }

    public override Vector3 GetForce()
    {
        return _seek.Seek(_player.position) * -1f;
    }
    
}
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using JetBrains.Annotations;
using Random = UnityEngine.Random;

public class SteeringBehaviors : MonoBehaviour
{
    private enum SteeringType
    {
        Seek, RunAway, Arrival, Wander
    }
    [SerializeField, Header("Steering Type")] 
    private SteeringType type;

    [SerializeField] [CanBeNull] private Transform target;

    [SerializeField] private float speed, maxSpeed, slowingRadius;
    
    
    private readonly Dictionary<string, Action> _actions = new Dictionary<string, Action>();
    private Vector3 _velocity, _steering, _desiredVelocity;

    [SerializeField, Header("Wander Settings"), Range(1f,10f)] private float timeChange;
    [SerializeField] private float circleDistance;
    [SerializeField] private float circleRadius;
    [SerializeField] private float timeAngleChange;
    private float _wanderAngle = 0;
    private Queue<Vector3> _wanderQueue = new Queue<Vector3>();
    private Vector3 _wanderTarget;
    private bool _isWandering = false;
    
    
    public Transform Target { set => target = value; }
    public float Speed { set => speed = value; }
    public float TimeChange { set => timeChange = value; }
    
    private void StartNewGame()
    {
        _actions.Add("Seek", CalculateSeek);
        _actions.Add("RunAway", RunAway);
        _actions.Add("Arrival", Arrival);
        _actions.Add("Wander", Wander);
    }

    private void Awake() => StartNewGame();

    private void Update()
    {
        if (!_actions.TryGetValue(type.ToString(), out var action)) return;
        _desiredVelocity = target.position - transform.position;

        if (type.ToString() != "Wander")
        {
            StopAllCoroutines();
            _isWandering = false;
        }
        
        action();
        Move(_steering);
    }
    
    private void Move(Vector3 steering)
    {
        _velocity += steering;
        _velocity = Vector3.ClampMagnitude(_velocity, maxSpeed);
        transform.position += _velocity * Time.deltaTime;
    }

    private void CalculateSeek()
    {
        _steering = Seek(target.position);
    }
    
    private Vector3 Seek(Vector3 seekTarget)
    {
        Vector3 desiredVelocity = ((seekTarget - transform.position).normalized * speed);
        return desiredVelocity - _velocity;
    }

    private void RunAway()
    {
        _steering = Seek(target.position) * -1;
    }
    
    private void Arrival()
    { 
        var distance = _desiredVelocity.magnitude;
        var factor = maxSpeed;
        
        if (distance < slowingRadius) factor *= (distance / slowingRadius);

        _desiredVelocity = _desiredVelocity.normalized * factor;
        _steering = _desiredVelocity - _velocity;
    }

    private void Wander()
    {
        CheckQueue();
        if (!_isWandering)
        {
            StartCoroutine(wanderSteering());
            StartCoroutine(ChangeAngle());
        }
        Vector3 displacement = GetDisplacementForce();
        
        _steering = Seek(_wanderTarget) + Seek(displacement);
    }

    private void CheckQueue()
    {
        if (_wanderQueue.Count > 0) return;

        var points = NPC.GetRandomPoints(50f, 9f, 10);
        foreach (var point in points)
        {
            Vector3 randomTarget = new Vector3(point.x, 0.15f, point.y);
            _wanderQueue.Enqueue(randomTarget);
        }
    }

    private Vector3 GetDisplacementForce()
    {
        Vector3 circleCenter = _velocity.normalized * circleDistance;
        Vector3 displacement = Vector3.forward * circleRadius;
        displacement = Quaternion.AngleAxis(_wanderAngle, Vector3.up) * displacement;
        
        return circleCenter + displacement;

    }

    IEnumerator wanderSteering()
    {
        _isWandering = true;
        while (true)
        {
            CheckQueue();
            _wanderTarget = _wanderQueue.Dequeue();
            yield return new WaitForSeconds(timeChange);
        }
    }

    IEnumerator ChangeAngle()
    {
        while (true)
        {
            _wanderAngle = Random.Range(-45f, 45f);
            yield return new WaitForSeconds(timeAngleChange);
        }
    }
    
}

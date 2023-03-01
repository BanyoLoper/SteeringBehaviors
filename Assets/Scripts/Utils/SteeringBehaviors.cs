using System.Collections.Generic;
using UnityEngine;
using System;

public class SteeringBehaviors : MonoBehaviour
{
    private enum SteeringType
    {
        Seek, RunAway, Arrival, Wander
    }
    [SerializeField, Header("Steering Type")] 
    private SteeringType type;

    [SerializeField] private Transform target;
    [SerializeField] private float speed, maxSpeed, slowingRadius;
    
    private readonly Dictionary<string, Action> _actions = new Dictionary<string, Action>();
    private Vector3 _velocity, _steering, _desiredVelocity;

    private void StartNewGame()
    {
        _actions.Add("Seek", CalculateSeek);
        _actions.Add("RunAway", RunAway);
        _actions.Add("Arrival", Arrival);
    }

    private void Awake() => StartNewGame();

    private void Update()
    {
        if (!_actions.TryGetValue(type.ToString(), out var action)) return;
        _desiredVelocity = target.position - transform.position;
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

}

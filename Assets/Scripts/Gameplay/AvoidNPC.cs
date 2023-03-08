using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class AvoidNPC : MonoBehaviour
{

    [SerializeField] private Transform goal;
    [SerializeField] private Transform start;
    [SerializeField] private Plane plane;
    
    private SeekBehavior _seek;

    private void Start()
    {
        _seek = gameObject.GetComponent<SeekBehavior>();
        _seek.seekPoint = goal.position;
    }

    private void Update()
    {
        _seek.seekPoint = plane.MouseClick == Vector3.zero ? goal.position : plane.MouseClick;
    }

    private void OnMouseDown()
    {
        transform.position = start.position;
        plane.MouseClick = Vector3.zero;
    }
}

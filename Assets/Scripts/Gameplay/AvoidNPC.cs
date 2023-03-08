using System;
using UnityEngine;

public class AvoidNPC : MonoBehaviour
{

    [SerializeField] private Transform goal;
    [SerializeField] private Transform start;

    private SeekBehavior _seek;

    private void Start()
    {
        _seek = gameObject.GetComponent<SeekBehavior>();
        _seek.seekPoint = goal.position;
    }

    private void OnMouseDown()
    {
        transform.position = start.position;
    }
}

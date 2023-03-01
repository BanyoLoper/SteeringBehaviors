using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    private Plane _plane;

    private void Awake()
    {
        _plane = GetComponent<Plane>();
    }

    private void OnMouseDown()
    {
        float distance;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit info))
        {
            playerTarget.position = info.point;
        }
        
    }
}

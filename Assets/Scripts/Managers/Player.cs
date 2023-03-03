using System;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem trailParticleSystem;
    [SerializeField] private int bounceParticleEmission = 20;
    [SerializeField] private Plane plane;

    public SeekBehavior Seek;

    private void Awake() => StartNewGame();

    private void StartNewGame()
    {
        UpdateVisualization();
        SetTrailEmission(true);
    }

    private void Update()
    {
        UpdateVisualization();
        SeekPointer();
    }

    private void UpdateVisualization() => trailParticleSystem.transform.localPosition =
        transform.localPosition;
    private void SetTrailEmission(bool status)
    {
        ParticleSystem.EmissionModule emission = trailParticleSystem.emission;
        emission.enabled = status;
    }

    private void SeekPointer()
    {
        if (plane.MouseClick.magnitude == 0) return;
        Seek.seekPoint = plane.MouseClick;
    }


}   

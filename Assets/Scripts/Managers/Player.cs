using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ParticleSystem trailParticleSystem;

    [SerializeField] private int bounceParticleEmission = 20;
    
    private Vector2 _position;

    private void Awake() => StartNewGame();

    private void StartNewGame()
    {
        _position = Vector2.zero;
        UpdateVisualization();
        SetTrailEmission(true);
    }

    private void Update()
    {
        UpdateVisualization();
    }

    public void UpdateVisualization() => trailParticleSystem.transform.localPosition =
        transform.localPosition;
    private void SetTrailEmission(bool status)
    {
        ParticleSystem.EmissionModule emission = trailParticleSystem.emission;
        emission.enabled = status;
    }
}   

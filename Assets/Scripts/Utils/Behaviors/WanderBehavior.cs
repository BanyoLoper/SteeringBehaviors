using System.Collections;
using UnityEngine;

public class WanderBehavior : SteeringBehavior
{
    [SerializeField, Header("Wander Set Up")]
    private float circleDistance = 2f;
    
    [SerializeField]
    private float circleRadius = 1f;
    
    [SerializeField, Header("Random setup")]
    private float targetTime = 2f;
    
    [SerializeField] 
    private float angleTime = 2f;
    
    [SerializeField] private float[] angleRange = {-90f, 90f};

    private bool _startCoroutine = false;
    private Vector3 _displacement = Vector3.zero;
    private Vector3 _randomTarget;
    private SeekBehavior _seek;
    private float _wanderAngle = 30f;
    
    private void Awake()
    {
        _seek = gameObject.GetComponent<SeekBehavior>();
    }
    
    public override Vector3 GetForce()
    {
        Vector3 wanderForce = Vector3.zero;

        if (!_startCoroutine)
        {
            _startCoroutine = true;
            StartCoroutine(ChangeTarget());
            StartCoroutine(ChangeAngle());
        }

        Vector3 circleCenter = rb.velocity.normalized * circleDistance;
        Vector3 displacement = (Vector3.forward * circleRadius);
        Quaternion rotation = Quaternion.AngleAxis(_wanderAngle, Vector3.up);

        displacement = rotation * displacement;
        
        return circleCenter + displacement;
    }

    IEnumerator ChangeTarget()
    {
        while (true)
        {
            _randomTarget = new Vector3(Random.Range(-11f, 11f),
                                        0f,
                                        Random.Range(-8f, 8f));
            _seek.seekPoint = _randomTarget;
            yield return new WaitForSeconds(targetTime);
        }
    }
    
    IEnumerator ChangeAngle()
    {
        while (true)
        {
            _wanderAngle = Random.Range(angleRange[0], angleRange[1]);
            yield return new WaitForSeconds(angleTime);
        }
    }

}

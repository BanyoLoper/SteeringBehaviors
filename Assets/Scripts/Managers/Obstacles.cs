using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int numberOfObstacles = 4;
    [SerializeField] private float zoneRadius = 15f;
    [SerializeField] private float separation = 2f;

    public List<Vector3> obstacleList = new List<Vector3>();

    private void Awake()
    {
        List<Vector2> points = GetRandomPoints(zoneRadius, separation, numberOfObstacles);
        LocateObjects(points);
    }

    public static List<Vector2> GetRandomPoints(float radius, float separation, int amount)
    {
        var points = new List<Vector2>();
        while (points.Count < amount)
        {
            Vector2 newPoint = Random.insideUnitCircle * radius;
            bool isValid = true;

            foreach (var point in points)
            {
                if (Vector2.Distance(newPoint, point) < separation)
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid) points.Add(newPoint);
        }
        return points;
    }
    
    private void LocateObjects(List<Vector2> points)
    {

        foreach (var point in points)
        {
            GameObject obstacle = Instantiate(obstaclePrefab, transform);
            obstacle.transform.position = new Vector3(point.x, 0.15f, point.y);
            obstacleList.Add(obstacle.transform.position);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject npcPrefab;
    [SerializeField, Header("xMin, xMax, yMin, yMax")] private Vector4 npcArea;
    [SerializeField] private int number = 4;
    [SerializeField] private float radius = 15f;
    [SerializeField] private float separation = 2f;

    private Transform _dummyTarget;
    private void Awake()
    {
        _dummyTarget = transform;
        LocateNpc();
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
    
    private void LocateNpc()
    {
        var points = GetRandomPoints(radius, separation, number);

        foreach (var point in points)
        {
            GameObject npc = Instantiate(npcPrefab);
            npc.transform.position = new Vector3(point.x, 0.15f, point.y);
        }
    }
}

using UnityEngine;

public class Plane : MonoBehaviour
{
    private Plane _plane;
    public Vector3 MouseClick = new Vector3(0f, 0f, 0f);

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
            MouseClick = info.point;
        }
    }
}

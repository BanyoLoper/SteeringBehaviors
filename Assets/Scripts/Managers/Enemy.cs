using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public SeekBehavior seek;
    
    private void Update()
    {
        seek.seekPoint = player.position;
    }
}

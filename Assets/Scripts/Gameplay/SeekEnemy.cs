using UnityEngine;

public class SeekEnemy : MonoBehaviour
{
    public Transform player;
    public SeekBehavior seek;
    
    private void Update()
    {
        seek.seekPoint = player.position;
    }
}

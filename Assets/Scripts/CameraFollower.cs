using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (player.position + new Vector3(0, 1, -5));
    }
}

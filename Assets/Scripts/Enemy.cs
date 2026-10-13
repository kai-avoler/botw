using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed;
    public GameObject character;
    public Rigidbody body;
    public int health;

    private Vector3 playerPos;
    private Vector3 distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = character.transform.position;
        distance = playerPos - transform.position;
        distance.y = 0f;
        distance = distance.normalized;

        // transform.position = playerPos;

        body.linearVelocity = new Vector3(distance.x * speed, body.linearVelocity.y, distance.z * speed);

        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider attack)
    {
        
        if (attack.name == "Attack(Clone)")
        {
            health = health - 1;
            Debug.Log(health);
        }
    }


}

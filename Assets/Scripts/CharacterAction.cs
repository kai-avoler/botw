using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAction : MonoBehaviour
{
    // private bool isRunning;
    private Vector2 walkInput;
    public Rigidbody body;
    public LayerMask ground;
    public LayerMask climbable;


    public float speed = 0.5f; 
    
    // public InputAction run;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        body.linearVelocity += new Vector3(walkInput.x, 0, walkInput.y) * speed;


    }

    void FixedUpdate()
    {

    }

    public void Walk(InputAction.CallbackContext c)
    {
        walkInput = c.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext c) 
    {
        if (c.started)
        {   

            if (Physics.Raycast(transform.position, Vector3.down, 1.5f, ground))
            {
                body.linearVelocity += new Vector3(0f, 5.0f, 0f);
            }


            
        }
    }

    public void Sprint(InputAction.CallbackContext c)
    {
        if(c.started)
        {
            body.linearVelocity = body.linearVelocity * 3;
        }
        else if (c.canceled)
        {
            body.linearVelocity = body.linearVelocity / 3;
        }
    }

    public void Climb(InputAction.CallbackContext c)
    {   
        Vector2 climbInput = c.ReadValue<Vector2>();
        Debug.Log(Physics.Raycast(transform.position, Vector3.forward, 1.5f, ground));
        if(Physics.Raycast(transform.position, Vector3.forward, 1.5f, ground))
        {
            body.linearVelocity += new Vector3(0, 3, 0);
        }
    }
    
}

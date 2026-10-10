using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAction : MonoBehaviour
{
    // private bool isRunning;
    private Vector2 walkInput;
    private Vector2 climbInput;
    private bool isGliding = false;
    public Rigidbody body;
    public LayerMask ground;
    public LayerMask climbable;


   
    public float walkSpeed = 0.5f; 
    public float sprintSpeed = 2.0f;
    private float speed;
    // public InputAction run;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position  + Vector3.down * 0.8f, Vector3.forward, 0.6f, ground))
        {
            body.linearVelocity = new Vector3(0, walkInput.y * 2, 0);
            body.useGravity = false;
        }
        else
        {
             body.linearVelocity = new Vector3(walkInput.x * speed, body.linearVelocity.y, walkInput.y * speed);
             body.useGravity = true;
             if (walkInput.magnitude < 0.01)
             {
                body.linearVelocity = new Vector3(0, body.linearVelocity.y, 0);
             }
        }
        
        if (isGliding)
        {
            if (body.linearVelocity.y < -1.0)
            {
                body.linearVelocity = new Vector3(body.linearVelocity.x, -1.0f ,body.linearVelocity.z);
            }
            
            if (Physics.Raycast(transform.position, Vector3.down, 1.5f, ground))
            {
                isGliding = false;
            }
        }

        Debug.Log(walkInput * speed);
        Debug.Log(walkInput * sprintSpeed);

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
            
            if (Physics.Raycast(transform.position, Vector3.forward, 1.5f, ground))
            {
                transform.position += (-transform.forward * 0.3f);
            }
            
            else if (Physics.Raycast(transform.position, Vector3.down, 1.5f, ground))
            {
                body.linearVelocity = new Vector3(body.linearVelocity.x, 5.0f, body.linearVelocity.z);
            }
            
            

            
        }
    }

    public void Sprint(InputAction.CallbackContext c)
    {
        if(c.started)
        {
            speed = sprintSpeed;
        }
        else if (c.canceled)
        {
            speed = walkSpeed;
        }

        

    }

    public void Paraglide(InputAction.CallbackContext c)
    {
        if(c.started)
        {
            if(!(Physics.Raycast(transform.position, Vector3.down, 4.0f, ground)))
            {
                isGliding = !isGliding;
            }
        }

       
        
    }

    // public void Climb(InputAction.CallbackContext c)
    // {   
    //     climbInput = c.ReadValue<Vector2>();
    //     Debug.Log(climbInput);
    // }
    
}

using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAction : MonoBehaviour
{
    private bool isJumping;
    private bool isRunning;

    public Rigidbody body;
    public InputAction walk;
    public InputAction jump;
    public InputAction run;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walk.Enable();
        jump.Enable();
        body = GetComponent<Rigidbody>();
        run.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(jump.WasPressedThisFrame())
        {
            isJumping = true;
        }

       
    }

    void FixedUpdate()
    {
        Vector2 input = walk.ReadValue<Vector2>();
        body.linearVelocity += new Vector3(input.x, 0, input.y) * 0.3f;
        
        if (isJumping)
        {
            body.linearVelocity += new Vector3(0f, 5.0f, 0f);
            isJumping = false;
        }

        if (isRunning)
        {   
            Debug.Log("spirng");
            body.linearVelocity = new Vector3(input.x, 0, input.y) * 300f;
        }
    }

    void sprint(InputAction.CallbackContext context)
    {
         if(context.started)
        {
            isRunning = true;
        }
        else if (context.canceled)
        {
            isRunning = false;
        }
    }
    
}

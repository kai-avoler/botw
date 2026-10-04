using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAction : MonoBehaviour
{
    public InputAction walk;
    public InputAction jump;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walk.Enable();
        jump.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = walk.ReadValue<Vector2>();

        transform.position += new Vector3(input.x, 0, input.y) * 0.3f;

        if (jump.WasPressedThisFrame())
        {
            transform.position += new Vector3(0f, 1.0f, 0f);
        }

    }
}

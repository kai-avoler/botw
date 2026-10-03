using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAction : MonoBehaviour
{
    public InputAction walk;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walk.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}

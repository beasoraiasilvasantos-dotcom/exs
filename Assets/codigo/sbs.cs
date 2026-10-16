using UnityEngine;
using UnityEngine.InputSystem;

public class sbs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public Rigidbody cubo;
    void Update()
    {
        cubo.AddForce(0,0,4);
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            cubo.AddForce(-4,0,0);
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            cubo.AddForce(4,0,0);
        }
    }
}

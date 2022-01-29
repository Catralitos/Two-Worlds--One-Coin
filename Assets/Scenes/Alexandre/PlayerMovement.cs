using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
    {
        
    public Rigidbody2D theRB;

    public float currentMoveSpeed = 5;
        
    public float currentJumpPower = 5;
        
    public bool isGrounded = false;

    private float inputX;

    void Update()
    {
        theRB.velocity = new Vector2(inputX * currentMoveSpeed, theRB.velocity.y);

        
    }
    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }
        
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded){
            theRB.velocity = new Vector2(theRB.velocity.x, currentJumpPower);
        }
    }
}


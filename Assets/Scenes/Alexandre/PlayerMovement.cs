using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
    {       
    public Rigidbody2D theRB;

    [HideInInspector] public bool canDash;
    public float moveSpeed = 5;
    [HideInInspector] public float currentMoveSpeed = 5;
    public float jumpPower = 5;

    public float currentJumpPower = 5;
        
    public bool isGrounded = false;

    private float inputX;

        private void Start()
        {
            currentJumpPower = jumpPower;
            currentMoveSpeed = moveSpeed;
        }


    void Update()
    {
        theRB.velocity = new Vector2(inputX * currentMoveSpeed, theRB.velocity.y);
        Debug.Log(theRB.velocity);
    
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


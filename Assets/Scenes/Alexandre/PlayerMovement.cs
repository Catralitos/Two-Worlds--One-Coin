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

    // Salto
    public float jumpPower = 5;
    public float currentJumpPower = 5;

    // Checar se está no chão        
    public bool isGrounded = false;

    // Movimento horizontal
    private float inputX;

    // Moeda
    public bool flippingCoin = false;

    private double flippingTime = 2;

        private void Start()
        {
            currentJumpPower = jumpPower;
            currentMoveSpeed = moveSpeed;
        }

    // Movimento horizontal
    void Update()
    {
        if (flippingCoin == false){
        theRB.velocity = new Vector2(inputX * currentMoveSpeed, theRB.velocity.y);
        }
        else {
            
            theRB.velocity = new Vector2(0f, theRB.velocity.y);
        }

        FlippingCoin();
    }
    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }
        
    // Salto
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && ! flippingCoin){
        
            theRB.velocity = new Vector2(theRB.velocity.x, currentJumpPower);
        }
    }

    // Flipping coin

        // When pressing:
    public void CoinFlipStart(InputAction.CallbackContext context)
    {
        if (context.performed){
            flippingCoin = true;
        }
    }

        // When realising
    public void CoinFlipEnd(InputAction.CallbackContext context)
    {
        if (context.performed){
            flippingCoin = false;
        }
    }

        // Espécie de Toggle
    public void FlippingCoin(){
        if (flippingCoin == false){
            flippingTime = 1;
        }
        else {
            flippingTime -= Time.deltaTime;

            if (flippingTime < 0){

                flippingCoin = false;
            }
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
    {       
    public Rigidbody2D theRB;

    // Dash
    public float dashDirection;

    public double dashTime = 0;

    public double dashTimeMax = 0.1;

    public bool canDash = true;

    public bool canDashAux = true;

    public bool canDashJump = false;

    public float dashSpeed = 30;

    public float dashCooldownMax = 3;

    public float dashCooldown = 0;

    // Speed
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
    public double flippingTimeMax = 1;

    public bool flippingCoin = false;

    public bool coinFlipped = false;

    private double flippingTime;

    private bool facingRight = false;

    private void Start()
    {

        facingRight = false;
        currentJumpPower = jumpPower;
        currentMoveSpeed = moveSpeed;
    }

    // Movimento horizontal
    void Update()
    {
        if ((facingRight && inputX < 0) || (!facingRight && inputX > 0))
        {
            Flip();
        }

        if (flippingCoin == false && dashTime == 0){
        theRB.velocity = new Vector2(inputX * currentMoveSpeed, theRB.velocity.y);
        }
        else {
            
            theRB.velocity = new Vector2(0f, theRB.velocity.y);
        }

        FlippingCoin();

        // Dash

        if (isGrounded){
            canDashJump = true;
        }

        if (dashTime > 0){
            theRB.velocity = new Vector2(dashDirection * dashSpeed, theRB.velocity.y);

            dashTime -= Time.deltaTime;

            dashCooldown = dashCooldownMax;
        }
        else
        {
            dashTime = 0;

            if (dashCooldown > 0)
            {
                dashCooldown -= Time.deltaTime;
            }

            if (dashCooldown <= 0 && canDashJump)
            {
                canDashAux = true;
            }
        }

        
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
        if (context.performed && dashTime <= 0){
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
            flippingTime = flippingTimeMax;
        }
        else {
            flippingTime -= Time.deltaTime;

            if (flippingTime < 0){
                coinFlipped = true;
                flippingCoin = false;
            }
        }
    }

    // Dash
    public void Dash(InputAction.CallbackContext context){
        if (context.performed && canDash && canDashAux && ! flippingCoin){
            dashDirection = inputX;
            dashTime = dashTimeMax;
            canDashAux = false;
            canDashJump = false;
        }
    }

    // Flip
    public void Flip()
    {
         facingRight = ! facingRight;
         Vector3 scale = transform.localScale;
         scale.x *= -1;
         transform.localScale = scale;
    }

}


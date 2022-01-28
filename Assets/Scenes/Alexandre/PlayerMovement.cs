using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {

        [HideInInspector] public bool canDash;
        public float moveSpeed = 5;
        [HideInInspector] public float currentMoveSpeed = 5;
        public float jumpPower = 5;

        public float currentJumpPower = 5;
        
        public bool isGrounded = false;

        private void Start()
        {
            currentJumpPower = jumpPower;
            currentMoveSpeed = moveSpeed;
        }

        void Update()
        {
            Jump();
            if (Input.GetKey(KeyCode.D)){
                Vector3 movement = new Vector3(1f, 0f, 0f);
                transform.position += movement * Time.deltaTime * currentMoveSpeed;
                }
            if (Input.GetKey(KeyCode.A)){
                Vector3 movement = new Vector3(-1f, 0f, 0f);
                transform.position += movement * Time.deltaTime * currentMoveSpeed;
                }
            
        }

        void Jump()
        {   if (Input.GetButtonDown("Jump") && isGrounded == true){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, currentJumpPower), ForceMode2D.Impulse);
        }
        }
        

    }
}

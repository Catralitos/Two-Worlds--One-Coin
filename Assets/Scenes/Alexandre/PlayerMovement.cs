using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jump = 5f;
    public bool isGrounded = false;
    void Start()
    {
        
    }

    void Update()
    {
        Jump();
        if (Input.GetKey(KeyCode.D)){
            Vector3 movement = new Vector3(1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
            }
        if (Input.GetKey(KeyCode.A)){
            Vector3 movement = new Vector3(-1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
            }
        
    }

    void Jump()
    {   if (Input.GetButtonDown("Jump") && isGrounded == true){
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
    }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xSpeed;
    Rigidbody2D rb2D;
    bool jumping;

    private void Awake()
    {
    }
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Movement();
    }
    private void FixedUpdate()
    {
        Jump();
    }


    void Movement()
    {
        xSpeed = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(xSpeed, rb2D.velocity.y);
    }

    void Jump()
    {
        if(jumping)
        {
            rb2D.AddForce(Vector2.up * 100);
            jumping = false;
        }
    }

    void PlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
    }
}

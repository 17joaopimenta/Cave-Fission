using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xSpeed;
    Rigidbody2D rb2D;
    bool jumping;
    public float playerSpeed;
    public float jumpPower;
    [SerializeField] LayerMask ground;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PlayerInputs();
        Movement();
    }
    private void FixedUpdate()
    {
        Jump();
    }


    void Movement()
    {
        xSpeed = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(xSpeed*playerSpeed, rb2D.velocity.y);
    }

    void Jump()
    {
        if(jumping)
        {
            rb2D.AddForce(Vector2.up * jumpPower);
            jumping = false;
        }
    }

    bool IsOnGround()
    {
        return Physics2D.OverlapCircle(transform.position, 1.05f, ground );
    }

    void PlayerInputs()
    {
        if (Input.GetButtonDown("Jump") && IsOnGround()) 
        {
            jumping = true;
        }
        
    }
}

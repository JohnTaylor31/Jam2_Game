using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float input;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;

    private Rigidbody2D rb2d;
    public Transform feetPosition;
    public float groundCheckCircle;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        input = UnityEngine.Input.GetAxisRaw("Horizontal");


        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded == true && UnityEngine.Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = Vector2.up * jumpForce; //Applies a force and direction when 'space' is pressed
        }
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(input * moveSpeed, rb2d.velocity.y);
    }
}

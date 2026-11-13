using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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

    //Start tutorial Message
    public GameObject startJumpText;
    public bool isStartSpacePressed;

    //Player start position
    Vector2 startPos;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isStartSpacePressed = true;

        startPos = transform.position;
    }

    
    void Update()
    {
        //input = UnityEngine.Input.GetAxisRaw("Horizontal");

        if (isStartSpacePressed)
        {
            startJumpText.SetActive(true);
            Time.timeScale = 0;
            if (UnityEngine.Input.GetButtonDown("Jump"))
            {
                isStartSpacePressed = false;
            }
        }
        else if(isStartSpacePressed == false)
        {
            startJumpText.SetActive(false);
            Time.timeScale = 1;
        }

            isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded == true && UnityEngine.Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = Vector2.up * jumpForce; //Applies a force and direction when 'space' is pressed
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
        }
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
    }
}

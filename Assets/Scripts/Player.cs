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

    //Food Variables
    public Food foodScript;
    public HealthFood healthFoodScript;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isStartSpacePressed = true;

        startPos = transform.position;

        foodScript.foodText.text = "Score: 0 ";
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Junk Food" && collision.gameObject.activeSelf == true)
        {
            collision.gameObject.SetActive(false);
            foodScript.currentFoodScore += foodScript.newFoodScore;
            foodScript.foodText.text = "Score: " + foodScript.currentFoodScore;
            Debug.Log("Junk Food Collected!" + foodScript.newFoodScore);
        }
        if(collision.gameObject.activeSelf == true && collision.gameObject.name == "Junk Food_Medium")
        {
            collision.gameObject.SetActive(false);
            foodScript.currentFoodScore += (foodScript.newFoodScore * 2);
            foodScript.foodText.text = "Score: " + foodScript.currentFoodScore;
            Debug.Log("Junk Food Collected!" + foodScript.newFoodScore);
        }
        if (collision.gameObject.activeSelf == true && collision.gameObject.name == "Junk Food_Heavy")
        {
            collision.gameObject.SetActive(false);
            foodScript.currentFoodScore += (foodScript.newFoodScore * 4);
            foodScript.foodText.text = "Score: " + foodScript.currentFoodScore;
            Debug.Log("Junk Food Collected!" + foodScript.newFoodScore);
        }
        if (collision.gameObject.name == "Health Food" && collision.gameObject.activeSelf == true)
        {
            collision.gameObject.SetActive(false);
            healthFoodScript.currentHealthfoodScore += healthFoodScript.HealthFoodScore;
            healthFoodScript.healthFoodText.text = "Score: " + healthFoodScript.currentHealthfoodScore;
        }
        if (collision.gameObject.activeSelf == true && collision.gameObject.name == "Health Food_Medium")
        {
            collision.gameObject.SetActive(false);
            healthFoodScript.currentHealthfoodScore += healthFoodScript.HealthFoodScore;
            healthFoodScript.healthFoodText.text = "Score: " + healthFoodScript.currentHealthfoodScore;
        }
        if (collision.gameObject.activeSelf == true && collision.gameObject.name == "Health Food_Heavy")
        {
            collision.gameObject.SetActive(false);
            healthFoodScript.currentHealthfoodScore += healthFoodScript.HealthFoodScore;
            healthFoodScript.healthFoodText.text = "Score: " + healthFoodScript.currentHealthfoodScore;
        }
    }
}

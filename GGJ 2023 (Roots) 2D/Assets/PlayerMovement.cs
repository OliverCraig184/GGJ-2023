using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    private bool isGrounded;
    public float checkRadius;
    public float Water;
    public float Hunger;
    public Image WaterBar;
    public Image HungerBar;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        Move();
        if (Input.GetKey(KeyCode.J) && (Water >= 0))
        {
            Water -= 1;
        }

        if (Input.GetKey(KeyCode.K) && (Hunger >= 0))
        {
            Hunger -= 1;
        }
        if (Input.GetKey(KeyCode.L) && (Water < 100))
        {
            Water += 1;
        }
        if (Input.GetKey(KeyCode.P))
        {
            Hunger += 1;
        }
    }

    void Update()
    {
        ProcessInputs();
        WaterBar.fillAmount = Water / 100;
        HungerBar.fillAmount = Hunger / 100;



    }
    private void ProcessInputs()
    {
        
        moveDirection = Input.GetAxis("Horizontal");
        
        if(Input.GetKey(KeyCode.W) && isGrounded)
        {
            isJumping = true;
        }
        




    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }
    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Text MyText;
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
    public Animator animator;
    public Transform pickupCheck;
    public LayerMask waterPickup;
    public LayerMask groundPickup;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(pickupCheck.position,checkRadius,waterPickup))
        {

            if (Water <= 50)
            {
                Water += 50;
            }
            else if(Water > 50)
            {
                Water += (100-Water);
            }
            


        }
        if (Physics2D.OverlapCircle(pickupCheck.position,checkRadius,groundPickup))
            {
                if (Hunger <= 50)
                {
                    Hunger += 50;
                }
                else if (Hunger > 50)
                {
                    Hunger += (100-Hunger);
                }
            }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        Move();
        if ((Water >= 0) & (Input.GetKey(KeyCode.J)))
        {
            Water -= 1;
        }

        if (Input.GetKey(KeyCode.K) & (Hunger >= 0))
        {
            Hunger -= 1;
        }
        if (Input.GetKey(KeyCode.L) & (Water <= 100))
        {
            Water += 1;
        }
        if (Input.GetKey(KeyCode.P) & (Hunger <= 100))
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
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
        if (Input.GetKey(KeyCode.W) && isGrounded)
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

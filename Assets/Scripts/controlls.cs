using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlls : MonoBehaviour
{
    Rigidbody2D rb;

    public float PlayerSpeed = 5f;
    public float jumpForce = 5f;

    private bool isGrounded = false;
    public Transform isGroundedChecker; //for empty object to be place under the character
    public float checkGroundRadius;
    public LayerMask groundLayer; //only check for collisions on "Ground" layer

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0.01f)
        {
            transform.localScale = Vector2.one;
        }
        else if (x < -0.01f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        float moveBy = x * PlayerSpeed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true; /* if the number of collisions isn't 0 at the "Ground" layer the character is on the ground and can jump upon pressing Space */
        }
        else
        {
            isGrounded = false;
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player2Movement : MonoBehaviour
{
    private Rigidbody2D rb2DTwo;
    public float MoveSpeed = 2f;
    public float JumpPower = 2f;
    private Vector2 p2x;
    public bool isGrounded;
    private float movement;
    private bool IsFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2DTwo = GetComponent<Rigidbody2D>();
    }

   private void FixedUpdate()
    {
        rb2DTwo.velocity = new Vector2(movement * MoveSpeed, rb2DTwo.velocity.y);
    }

  //  void Move()
   // {
       
 //   }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
           movement = -1;
        }

        if (Input.GetKey(KeyCode.L))
        {
            movement = 1;
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            movement = 0;
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            movement = 0;
        }

        //Jump controls for player 2
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isGrounded)
            {
                p2x = new Vector2(rb2DTwo.velocity.x, JumpPower);
                rb2DTwo.velocity = p2x;
            }
        }

        if (Input.GetKeyUp(KeyCode.I) && rb2DTwo.velocity.y > 0f)
        {
            rb2DTwo.velocity = new Vector2(rb2DTwo.velocity.x, rb2DTwo.velocity.y * 0.5f);
        }

        Flip();
    }

    void Flip()
    {
        if (IsFacingRight && movement < 0f || !IsFacingRight && movement > 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

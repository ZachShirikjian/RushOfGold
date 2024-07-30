using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //REFERENCES//
    private Rigidbody2D rb2D;
    public float KBforce;
    public float MoveSpeed = 2f;
    public float JumpPower = 2f;
    private Vector2 p1x;
    public bool isGrounded;
    private float movement;
    private bool IsFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(movement * MoveSpeed, rb2D.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            movement = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement = 1;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            movement = 0;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            movement = 0;
        }

        //Jump and Attack controls for Player 1
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isGrounded)
            {
                p1x = new Vector2(rb2D.velocity.x, JumpPower);
                rb2D.velocity = p1x;
            }
        }
        if (Input.GetKeyUp(KeyCode.I) && rb2D.velocity.y > 0f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("P2 Attack Hitbox"))
        {
            Debug.Log(" P1 Got Hit");
            var dirrection = rb2D.transform.position - collision.transform.position;
            rb2D.AddForce(dirrection * KBforce);
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES//
    public float speed; 
    
    //REFERENCES//
    public Rigidbody2D rb2D;
    public float MoveSpeed = 5f;
    public float JumpPower = 5f;
    public int coinWallet;
    private Vector2 p1x;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        coinWallet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Sidways movement control for player 1
        if (Input.GetKey(KeyCode.A))
        {
            if (isGrounded)
            {
               p1x = new Vector2(-1f, 0f);
               rb2D.AddForce(p1x * MoveSpeed);
            }
            else
            {
                p1x = new Vector2(0, 0f);
                rb2D.AddForce(p1x * MoveSpeed);
            }  
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (isGrounded)
            {
                p1x = new Vector2(1f, 0f);
                rb2D.AddForce(p1x * MoveSpeed);
            }
            else
            {
                p1x = new Vector2(0, 0f);
                rb2D.AddForce(p1x * MoveSpeed);
            }
        }

        //Jump and Attack controls for Player 1
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                p1x = new Vector2(0, 1f);
                rb2D.AddForce(p1x * JumpPower);
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            coinWallet += 1;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }


}

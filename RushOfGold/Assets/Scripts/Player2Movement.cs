using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player2Movement : MonoBehaviour
{
    public Rigidbody2D rb2D2;
    public float MoveSpeed = 5f;
    public float JumpPower = 5f;
    public int coinWallet;
    private Vector2 p2x;
    private bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Sideways player control for player 2 
        if (Input.GetKey(KeyCode.J))
        {
            p2x = new Vector2(-1f, 0f);
            rb2D2.AddForce(p2x * MoveSpeed);
        }

        if (Input.GetKey(KeyCode.L))
        {
            p2x = new Vector2(1f, 0f);
            rb2D2.AddForce(p2x * MoveSpeed);
        }


        //Jump controls for player 2
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isGrounded)
            {
                p2x = new Vector2(0f, 1f);
                rb2D2.AddForce(p2x * JumpPower);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("coin"))
        {
            coinWallet += 1;

        }
        else
        {
            isGrounded = false;
        }
    }
}

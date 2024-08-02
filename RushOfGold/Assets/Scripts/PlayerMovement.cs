using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES//
    public float MoveSpeed = 2f;
    public float JumpPower = 2f;
    private Vector2 p1x;
    public bool isGrounded;
    private float movement;
    private bool IsFacingRight = true;
    public bool pickedUp = false;

    //REFERENCES//
    private Rigidbody2D rb2D;

    //Reference to the Moneybag prefab 
    public GameObject moneyBag;

    //Spawn Position of the Moneybag 
    public Transform moneyBagSpawnPos;

    //Reference to the Player1CoinWallet
    private GameManager gm;

    //Reference to the Attack script 
    private PlayerAttack playerAttackScript; 

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAttackScript = GetComponentInChildren<PlayerAttack>();
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(movement * MoveSpeed, rb2D.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        //If you have at least 10 coins and press the Q button
        //Spawn the Moneybag 
        if (gm.p1CoinWallet >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Q) && pickedUp == false)
            {
                Debug.Log("Spawn Moneybag");
                Instantiate(moneyBag, moneyBagSpawnPos);
                pickedUp = true;
                playerAttackScript.canAttack = false;
            }
            //If you've already picked up a Moneybag, 
            //Throw it and reset your coins.
            else if (Input.GetKeyDown(KeyCode.Q) && pickedUp == true)
            {
                Debug.Log("Throw moneyBag");
                gm.p1CoinWallet = 0;
                pickedUp = false;
                playerAttackScript.canAttack = true;
            }

        }

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
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                p1x = new Vector2(rb2D.velocity.x, JumpPower);
                rb2D.velocity = p1x;
            }
        }
        if (Input.GetKeyUp(KeyCode.W) && rb2D.velocity.y > 0f)
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player2Movement : MonoBehaviour
{
    //VARIABLES//
    public float MoveSpeed = 2f;
    public float JumpPower = 2f;
    private Vector2 p2x;
    public bool isGrounded;
    private float movement;
    private bool IsFacingRight = true;
    public bool pickedUp = false;

    //REFERENCES//
    private Rigidbody2D rb2DTwo;

    //Reference to the Moneybag prefab 
    public GameObject moneyBag;

    //Spawn Position of the Moneybag 
    public Transform moneyBagSpawnPos;

    //Reference to the Player1CoinWallet
    private GameManager gm;

    //Reference to the Attack script 
    private Player2Attack playerAttackScript;

    // Start is called before the first frame update
    void Start()
    {
        rb2DTwo = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAttackScript = GetComponentInChildren<Player2Attack>();
    }

    private void FixedUpdate()
    {
        rb2DTwo.velocity = new Vector2(movement * MoveSpeed, rb2DTwo.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //If you have at least 10 coins and press the Q button
        //Spawn the Moneybag 
        if (gm.p2CoinWallet >= 1)
        {
            if (Input.GetKeyDown(KeyCode.O) && pickedUp == false)
            {
                Debug.Log("Spawn Moneybag");
                Instantiate(moneyBag, moneyBagSpawnPos);
                pickedUp = true;
                playerAttackScript.canAttack = false;
            }
            //If you've already picked up a Moneybag, 
            //Throw it and reset your coins.
            else if (Input.GetKeyDown(KeyCode.O) && pickedUp == true)
            {
                Debug.Log("Throw moneyBag");
                gm.p1CoinWallet = 0;
                pickedUp = false;
                playerAttackScript.canAttack = true;
            }

        }

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

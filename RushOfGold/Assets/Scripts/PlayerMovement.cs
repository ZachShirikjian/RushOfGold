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

    //Reference to the Default Moneybag prefab 
    public GameObject moneyBag;

    //The GameObject referencing the clone of the Moneybag spawning in 
    private GameObject newMoneyBag; 

    //Spawn Position of the Moneybag 
    public Transform moneyBagSpawnPos;

    //Reference to the Player1CoinWallet
    private GameManager gm;

    //Reference to the Attack script 
    private PlayerAttack playerAttackScript;

    //Reference to Animator 
    private Animator anim;

    //Reference to AudioManager
    private AudioManager audioManager;

    //Reference to SFXSource
    private AudioSource sfxSource;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAttackScript = GetComponentInChildren<PlayerAttack>();
        anim = GetComponent<Animator>();
        audioManager = GameObject.Find("AudioSources").GetComponent<AudioManager>();
        sfxSource = GameObject.Find("SFXSource").GetComponent<AudioSource>();
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

                //Instantiates a Moneybag prefab at the money bag spawn position as a child of the Player
                //Spawns a new Money Bag GameObject to allow its prefab to be separated from the Player transform. 
                newMoneyBag = Instantiate(moneyBag, moneyBagSpawnPos);
                newMoneyBag.GetComponent<Player1Moneybag>().numCoins = gm.p1CoinWallet;
                pickedUp = true;
                playerAttackScript.canAttack = false;
                sfxSource.PlayOneShot(audioManager.moneybagSpawn);
            }
            //If you've already picked up a Moneybag, 
            //Throw it and reset your coins.

            //Detach it from the Player so the arc doesn't change with player movement.
            else if (Input.GetKeyDown(KeyCode.Q) && pickedUp == true)
            {
                Debug.Log("Throw moneyBag");
                anim.SetTrigger("ThrowMoneybag");
                sfxSource.PlayOneShot(audioManager.moneybagThrow);
                newMoneyBag.transform.parent = null;
                gm.p1CoinWallet = 0;
                pickedUp = false;
                playerAttackScript.canAttack = true;
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            movement = -1;
            anim.SetBool("isWalking", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement = 1;
            anim.SetBool("isWalking", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            movement = 0;
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            movement = 0;
            anim.SetBool("isWalking", false);
        }

        //Jump and Attack controls for Player 1
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                p1x = new Vector2(rb2D.velocity.x, JumpPower);
                rb2D.velocity = p1x;
                sfxSource.PlayOneShot(audioManager.playerJump);
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

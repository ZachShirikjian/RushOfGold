using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//This script was referenced from rockwellcreation's script on Player attacking in the Unity Forums:
//https://discussions.unity.com/t/solved-simple-attack-function-with-cooldown-still-spammable/654830 

//Used for the PlayerAttack Collider child GameObject for Player 2.
public class Player2Attack : MonoBehaviour
{

    //VARIABLES//
    public float attackCooldown = 0.5f;
    public float KBforce;
    public bool attacking; //Bool checking if you're currently attacking or not 
    public bool canAttack = true;

    //REFERENCES// 
    private Animator anim; 
    private BoxCollider2D attackCollider;
    private GameObject attackTarget;
    private Rigidbody2D targetRD2D;

    //Reference to AudioManager
    private AudioManager audioManager;

    //Reference to SFXSource
    private AudioSource sfxSource;

    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        canAttack = true;
        attackCollider = GetComponent<BoxCollider2D>();
        anim = GetComponentInParent<Animator>();
        attackCollider.enabled = false;
        audioManager = GameObject.Find("AudioSources").GetComponent<AudioManager>();
        sfxSource = GameObject.Find("SFXSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //If you press the H Key (Attack for P2) and you're not currently attacking and the cooldown is 
    void Update()
    {
        //Enables the player to attack when pressing their respective key. 
        //After the cooldown ends, allow the player to attack again. 
        if (Input.GetKeyDown(KeyCode.H) && !attacking && canAttack && attackCooldown > 0)
        {
            attacking = true;
            attackCollider.enabled = true;
            anim.SetTrigger("Attacking");
            sfxSource.PlayOneShot(audioManager.playerPunch);
            // Attack();
        }

        //When attacking, if the cooldown is active, subtract from the attackCooldown
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }

        //If the cooldown is over, allow players to attack again.
        else if(attackCooldown <= 0)
        {
            attacking = false;
            attackCollider.enabled = false;
            attackCooldown = 0.5f;
        }
    }



    //If Player 2's trigger collider touches Player 1,
    //Call the Player 1 method to be knocked back. 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player1")
        {
            attackTarget = other.gameObject;
            other.gameObject.GetComponent<Animator>().SetTrigger("TakingDamage");
            sfxSource.PlayOneShot(audioManager.takingDamage);
            targetRD2D = other.GetComponent<Rigidbody2D>();
            Debug.Log("Player 1 was hit!");
            var dirrection = attackTarget.transform.position - this.transform.position;
            targetRD2D.AddForce(dirrection * KBforce);
        }
    }
}

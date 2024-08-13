using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//This script was referenced from rockwellcreation's script on Player attacking in the Unity Forums:
//https://discussions.unity.com/t/solved-simple-attack-function-with-cooldown-still-spammable/654830 

//Used for the PlayerAttack Collider child GameObject for Player 1.
public class PlayerAttack : MonoBehaviour
{

    //VARIABLES//
    public float attackCooldown = 0.5f;
    public float KBforce;
    public bool attacking; //Bool checking if you're currently attacking or not 
    public bool canAttack = false;
    //REFERENCES// 
    private BoxCollider2D attackCollider;
    private GameObject attackTarget;
    private Rigidbody2D targetRD2D;

    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        canAttack = true;
        attackCollider = GetComponent<BoxCollider2D>();
        attackCollider.enabled = false;
    }

    // Update is called once per frame
    //If you press the F Key (Attack for P1) and you're not currently attacking and the cooldown is 
    void Update()
    {
        //Enables the player to attack when pressing their respective key. 
        //After the cooldown ends, allow the player to attack again. 
        if (Input.GetKeyDown(KeyCode.F) && !attacking && attackCooldown > 0)
        {
            attacking = true;
            attackCollider.enabled = true;

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



    //If Player 1's trigger collider touches Player 2,
    //Call the Player 2 method to be knocked back. 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player2")
        {
            attackTarget = other.gameObject;
            targetRD2D = other.GetComponent<Rigidbody2D>();
            Debug.Log("Player 2 was hit!");
            var dirrection = attackTarget.transform.position - this.transform.position;
            targetRD2D.AddForce(dirrection * KBforce);

        }
    }
            
        
    
}


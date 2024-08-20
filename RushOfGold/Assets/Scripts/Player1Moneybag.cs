using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class Player1Moneybag : MonoBehaviour
{
    // Start is called before the first frame update

    //VARIABLES//
    private float curveAnimation;
    private Vector2 coinPot;

    //Reference to Player 1 
    private GameObject player1;

    //Vector 2 for the Money bag position to spawn the Moneybag above the Player's Head. 
    private Vector2 moneyBagPosition;

    //The number of coins inside this Moneybag, changes when spawned
    public int numCoins; 
    void Start()
    {
        player1 = GameObject.Find("Player1");

        coinPot = new Vector2(-2, -4.75f);
    }

    //Move the moneybag relative to the player's movement 
    void Update()
    {
        //If Player 1 is still holding onto the Moneybag, ensure the Moneybag moves relative to the Player.
        if(this.gameObject.transform.parent != null)
        {
            Debug.Log("Moneybag Follow");
            //Set the moneyBagPosition Vector2 to the player's current movement + an offset. 
            moneyBagPosition = new Vector2(player1.transform.position.x, player1.transform.position.y + 1);

            //Update the Money Bag's transform position based on the MoneyBagPosition Vector2. 
            transform.position = moneyBagPosition;
        }

        //If the Player presses Q/O again to throw the Moneybag,
        //And the Moneybag is no longer a child of the Player,
        //Set its transform position to be in an arc. 
        else if(this.gameObject.transform.parent == null)
        {
            Debug.Log("Moneybag Throw");
            curveAnimation += Time.deltaTime;

            //curveAnimation = curveAnimation % 1;

            transform.position = MathParabola.Parabola2D(moneyBagPosition, coinPot, 1f, curveAnimation / 1f);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player 1 Pot")
        {
            Debug.Log("Hit barrel");
            Destroy(this.gameObject);
        }
    }
}

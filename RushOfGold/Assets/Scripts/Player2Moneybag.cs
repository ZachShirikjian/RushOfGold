using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Moneybag : MonoBehaviour
{
    // Start is called before the first frame update

    //VARIABLES//

    //Reference to Player 2 
    private GameObject player2;

    //Vector 2 for the Money bag position to spawn the Moneybag above the Player's Head. 
    private Vector2 moneyBagPosition;

    //The number of coins inside this Moneybag, changes when spawned
    public int numCoins;

    void Start()
    {
        player2 = GameObject.Find("Player2");
    }

    //Move the moneybag relative to the player's movement 
    void Update()
    {
        //Set the moneyBagPosition Vector2 to the player's current movement + an offset. 
        moneyBagPosition = new Vector2(player2.transform.position.x, player2.transform.position.y + 1);

        //Update the Money Bag's transform position based on the MoneyBagPosition Vector2. 
        transform.position = moneyBagPosition;
    }

    //If a Player presses the Q key again after picking up a money bag, 
    //Throw the Moneybag in an arc. 
}

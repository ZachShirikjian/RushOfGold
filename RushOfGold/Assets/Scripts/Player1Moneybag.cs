using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Moneybag : MonoBehaviour
{
    // Start is called before the first frame update

    //VARIABLES//

    //Reference to Player 1 
    private GameObject player1;

    //Vector 2 for the Money bag position to spawn the Moneybag above the Player's Head. 
    private Vector2 moneyBagPosition; 

    void Start()
    {
        player1 = GameObject.Find("Player1");
    }

    //Move the moneybag relative to the player's movement 
    void Update()
    {
        //Set the moneyBagPosition Vector2 to the player's current movement + an offset. 
        moneyBagPosition = new Vector2(player1.transform.position.x, player1.transform.position.y + 1);

        //Update the Money Bag's transform position based on the MoneyBagPosition Vector2. 
        transform.position = moneyBagPosition;
    }

    //If a Player presses the Q key again after picking up a money bag, 
    //Throw the Moneybag in an arc. 
}

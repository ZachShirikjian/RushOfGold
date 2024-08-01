using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Moneybag : MonoBehaviour
{
    // Start is called before the first frame update

    //REFERENCES//
    //Reference to the Moneybag prefab 
    public GameObject moneyBag;

    //Spawn Position of the Moneybag 
    public Transform moneyBagSpawnPos; 

    void Start()
    {
        
    }

    //If you have at least 10 coins and press the Q key,
    //Spawn a moneybag at the moneyBagSpawnPos (above the Player's head).
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(moneyBag, moneyBagSpawnPos);
        }
    }
}

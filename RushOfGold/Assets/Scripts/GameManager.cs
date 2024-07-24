using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //VARIABLES//
    public int timeRemaining = 60; //The Time remaining within a match 
    public int p1Lives = 3; //Number of Lives Player 1 has
    public int p2Lives = 3; //Number of Lives Player 2 has 
    public int p1Coins = 0; //Amount of Coins Player 1 has 
    public int p2Coins = 0; //Amount of Coins Player 2 has 
    
    //REFERENCES//

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Resets the Lives & Coins for P1 & P2, and the timer for each new level.
    public void ResetValues()
    {
        p1Lives = 3;
        p2Lives = 3;
        timeRemaining = 60;
        p1Coins = 0;
        p2Coins = 0; 
    }
}

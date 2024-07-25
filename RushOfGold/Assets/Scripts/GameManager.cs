using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //VARIABLES//
    public bool timeRunning = true; //Bool to check if the timer is running or not
    public int timeRemaining = 60; //The Time remaining within a match 
    public int p1Lives = 3; //Number of Lives Player 1 has
    public int p2Lives = 3; //Number of Lives Player 2 has 
    public int p1Coins = 0; //Amount of Coins Player 1 has 
    public int p2Coins = 0; //Amount of Coins Player 2 has 

    
    //REFERENCES//
    //private Canvas canvas;
    public TextMeshProUGUI timerText; 
    public TextMeshProUGUI countdownTimer;

    public TextMeshProUGUI p1CoinWallet;
    public TextMeshProUGUI p2CoinWallet;

    private GameObject player1;
    private PlayerMovement p1Script;
    private GameObject player2;
    private Player2Movement p2Script;

  //  private UIHandler uiScript; //script to handle the UI components 

    // Start is called before the first frame update

    //Reset the Values of each Player's Coins & Lives, & Timer
    //Reference the UI script & begin handling UI aspects
    void Start()
    {
       // canvas = GameObject.Find("Canvas");
        ResetValues();
        ResetUI();
        StopAllCoroutines();
        StartCoroutine(NewRoundCountdown());
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        p1Script = player1.GetComponent<PlayerMovement>();
        p2Script = player2.GetComponent<Player2Movement>();
        //StartCoroutine(GameTimer());
       // StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        p1CoinWallet.text = p1Script.coinWallet.ToString();
        p2CoinWallet.text = p2Script.coinWallet.ToString();
    }

    public IEnumerator NewRoundCountdown()
    {
        for (int i = 3; i > 0; i--)
        {
            if(i > 0)
            {
                yield return new WaitForSeconds(1f);
                countdownTimer.text = i.ToString();
            }
            else if (i <=0)
            {
                countdownTimer.text = "GO!";
                yield return new WaitForSeconds(0.5f);
                countdownTimer.text = "";
                StartCoroutine(GameTimer());
            }
            
        }
    }
    //Do the timer counting down from timeRemaining (60)
    //Reduce the amount of time left by 1 second every second.
    public IEnumerator GameTimer()
    {
        for(int i = timeRemaining; i > 0; i--)
        {
            if(timeRunning == true)
            {
                if(timeRemaining > 0)
                {
                    yield return new WaitForSeconds(1f);
                    timeRemaining--;
                    timerText.text = timeRemaining.ToString();
                    Debug.Log(timeRemaining);
                }
             
                if(timeRemaining <= 0)
                {
                    StopTimer();
                }
            }

            if(timeRunning == false)
            {
                Debug.Log("STOP TIMER");
                break;
            }
            
        }
    }

    public void StopTimer()
    {
        Debug.Log("Time's Up!");
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

    //Resets the UI of the Game 
    public void ResetUI()
    {
        timerText.text = timeRemaining.ToString();
        countdownTimer.text = "3";
    }

    //Start the 3,2,1, GO Countdown before the game begins 
}

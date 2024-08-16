using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //VARIABLES//
    public bool gamePaused = false; //Checks to see if the Game is Paused or not. 
    public bool timeRunning = false; //Bool to check if the timer is running or not
    public int timeRemaining = 60; //The Time remaining within a match 
    public int p1CoinBarrel = 0; //Coin Barrel for Player 1
    public int p2CoinBarrel = 0; //Coin Barrel for Player 2
    public int p1CoinWallet = 0; //The Coin Wallet for Player 1
    public int p2CoinWallet = 0; //The Coin Wallet for Player 2 
    public int p1Lives = 3; //Number of Lives Player 1 has
    public int p2Lives = 3; //Number of Lives Player 2 has 

    public Transform p1SpawnPos; //Starting Position GameObject for Player1
    public Transform p2SpawnPos; //Starting Position GameObject for Player2 

    //REFERENCES//
    //private Canvas canvas;

    //UI REFERENCES//
    public GameObject pauseMenu; //Reference to the Pause Menu
    public GameObject GameWin; //Reference to the Win Screen
    public TextMeshProUGUI timerText; 
    public TextMeshProUGUI countdownTimer;

    //Coin Wallet UI for P1/P2
    public TextMeshProUGUI p1CoinWalletText;
    public TextMeshProUGUI p2CoinWalletText;

    //Coin Barrel UI
    public TextMeshProUGUI p1CoinBarrelText;
    public TextMeshProUGUI p2CoinBarrelText;

    //Lives UI
    public TextMeshProUGUI p1LivesText;
    public TextMeshProUGUI p2LivesText;

    //PLAYER 1/2 REFERENCES//
    private GameObject player1;
    private PlayerMovement p1Script;
    private GameObject player2;
    private Player2Movement p2Script;

  //  private UIHandler uiScript; //script to handle the UI components 

  //REFERENCE TO AUDIOMANAGER SCRIPT FOR GETTING SFX & MUSIC CLIPS//
    public AudioManager audioManager; 

  //REFERENCE TO THE MUSIC AUDIO SOURCE FOR PLAYING MUSIC//
    private AudioSource musicSource; 
    private AudioSource sfxSource;

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

        p1Script.enabled = false;
        p2Script.enabled = false;

        //Reset the Spawn Position of Player 1 and Player 2 every time a new stage is loaded
        player1.transform.position = p1SpawnPos.position;
        player2.transform.position = p2SpawnPos.position;

        timeRunning = false;
        gamePaused = false;
        pauseMenu.SetActive(false);
        GameWin.SetActive(false);

        musicSource = GameObject.Find("MusicSource").GetComponent<AudioSource>();
        sfxSource = GameObject.Find("SFXSource").GetComponent<AudioSource>();
        //StartCoroutine(GameTimer());
       // StartCountdown();
    }

    //Ensure the P1/P2 Coin Wallet & on-screen UI elements are updated with their in-game values 
    void Update()
    {
        p1CoinBarrelText.text = p1CoinBarrel.ToString();
        p2CoinBarrelText.text = p2CoinBarrel.ToString();

        p1CoinWalletText.text = p1CoinWallet.ToString();
        p2CoinWalletText.text = p2CoinWallet.ToString();

        p1LivesText.text = p1Lives.ToString();
        p2LivesText.text = p2Lives.ToString();

        //If either Player presses P while the game timer is running, Pause the Game. 
        if(Input.GetKeyDown(KeyCode.P) && timeRunning == true)
        {
            PauseGame();
        }

    }

    //PAUSE MENU TO ALLOW FOR IN-GAME PAUSING, call this method when the P key is pressed. 
    public void PauseGame()
    {
        if(gamePaused == true)
        {
            gamePaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        else if(gamePaused == false)
        {
            gamePaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
 
    }

    public IEnumerator NewRoundCountdown()
    {
        for (int i = 3; i >= 0; i--)
        {
            if(i > 0)
            {
                yield return new WaitForSeconds(1f);
                countdownTimer.text = i.ToString();
            }
            
            if (i <= 0)
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

    //Enables P1/P2 movement after countdown timer ends! 
    public IEnumerator GameTimer()
    {
        timeRunning = true;
        p1Script.enabled = true;
        p2Script.enabled = true;

        //Plays the Level 1 theme of our game 
        musicSource.PlayOneShot(audioManager.level1Theme);

        for (int i = timeRemaining; i > 0; i--)
        {
            if(timeRunning == true)
            {
                if(timeRemaining > 0)
                {
                    yield return new WaitForSeconds(1f);
                    timeRemaining--;
                    timerText.text = timeRemaining.ToString();
                    //Debug.Log(timeRemaining);
                }
             
                if(timeRemaining <= 0)
                {
                    StopTimer();
                    CheckScores();
                }
            }

            if(timeRunning == false)
            {
                Debug.Log("STOP TIMER");
                StopTimer();
                break;
            }
            
        }
    }

    //Stop the Timer, after 60 seconds have passed OR until a player loses all of their lives. 
    public void StopTimer()
    {
        Debug.Log("Time's Up!");
        timeRunning = false;

        p1Script.enabled = false;
        p2Script.enabled = false;

    }

    //Check the Scores between Player 1 and Player 2 if time goes to 0 
    public void CheckScores()
    {
        //If Player 1 has more coins in their barrel than Player 2
        //Player 1 Wins 
        if(p1CoinBarrel > p2CoinBarrel)
        {
            Debug.Log("Player 1 Wins!");
            Player1Win();
        }

        //If Player 2 has more coins in their barrel than Player 1
        //Player 2 Wins 
        else if (p2CoinBarrel > p1CoinBarrel)
        {
            Debug.Log("Player 2 Wins!");
            Player2Win();
        }

        //If the Coin Barrel amounts between both players match 
        //Call it a tie. 
        else if(p1CoinBarrel == p2CoinBarrel)
        {
            Debug.Log("DRAW");
            Draw();
        }
    }

    //Resets the TimeScale, Lives & Coins for P1 & P2, and the timer for each new level.
    public void ResetValues()
    {
        p1Lives = 3;
        p2Lives = 3;
        timeRemaining = 60;
        p1CoinWallet = 0;
        p2CoinWallet = 0;
        p1CoinBarrel = 0;
        p2CoinBarrel = 0;
        Time.timeScale = 1f;
    }

    //Resets the UI of the Game 
    public void ResetUI()
    {
        timerText.text = timeRemaining.ToString();
        countdownTimer.text = "3";
    }

    //Subtracts 1 Life from a Player after falling off-stage.
    public void LoseLife(int playerNumber)
    {
        if(playerNumber == 1)
        {
            p1Lives--;
            p1LivesText.text = p1Lives.ToString();

            if(p1Lives <= 0)
            {
                StopTimer();
            }

            //Resets P1's position to their Spawn Position on death. 
            else if(p1Lives > 0)
            {
                p1CoinWallet = p1CoinWallet / 2;
                player1.transform.position = p1SpawnPos.position;
            }
        }

        else if(playerNumber == 2)
        {
            p2Lives--;
            p2LivesText.text = p2Lives.ToString();

            if (p2Lives <= 0)
            {
                StopTimer();
            }

            else if(p2Lives > 0)
            {
                p2CoinWallet = p2CoinWallet / 2;
                player2.transform.position = p2SpawnPos.position;
            }
        }
    }

    public void Player1Win()
    {
     
    }

    public void Player2Win()
    {

    }

    public void Draw()
    {
        
    }
    //Update the Coin Wallet for P1/P2 & ensure their max is only 10 at a time 
}

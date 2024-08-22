using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinBarrelCounter : MonoBehaviour
{
    //public TextMeshProUGUI CoinDisplay;
    public int coinAmount;
    private GameManager gm;

    //Reference to AudioManager
    private AudioManager audioManager;

    //Reference to SFXSource
    private AudioSource sfxSource;

    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 0;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioSources").GetComponent<AudioManager>();
        sfxSource = GameObject.Find("SFXSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If Player 1's Moneybag touches this goal (if the GameObject is Moneybag) 
        if (collision.gameObject.CompareTag("Moneybag"))
        {

            //Set the P1CoinBarrel amount to the Number of Coins in Player 1's Moneybag
            sfxSource.PlayOneShot(audioManager.barrelGoal);
            gm.p1CoinBarrel += collision.gameObject.GetComponent<Player1Moneybag>().numCoins;
            Destroy(collision.gameObject);
        }

        //If Player 2's Moneybag touches this goal (if the GameObject is MoneybagP2)
        else if (collision.gameObject.CompareTag("MoneybagP2"))
        {
            // Read how many coins are in the moneybag and add that to the barrel's coin amount
            //Set the P2CoinBarrel amount to the Number of Coins in Player 2's Moneybag
            sfxSource.PlayOneShot(audioManager.barrelGoal);
            gm.p2CoinBarrel += collision.gameObject.GetComponent<Player2Moneybag>().numCoins;
            Destroy(collision.gameObject);

        }
    }
}

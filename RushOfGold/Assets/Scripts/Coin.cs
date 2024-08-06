using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //REFERENCES//
    private GameManager gm; //Reference to GameManager for adjusting score of P1/P2 coins 
    //private AudioSource audioSource; //Reference to the Audio Source on the Coin GameObject 
    public AudioClip coinCollect; //Audio clip we want to play when players collect coins 

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //audioSource = GetComponent<AudioSource>();

        //Destroys coins after 3 seconds to de-spawn them.
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //If Player 1 picks up a coin,
        //Update their coin wallet.
        if(other.tag == "Player")
        {
            if(other.gameObject.name == "Player1")
            {
                gm.p1CoinWallet++;
                //Play the Coin Collect SFX at the spot where the player collected the coin itself 
                AudioSource.PlayClipAtPoint(coinCollect, transform.position);
                gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
            else if(other.gameObject.name == "Player2")
            {
                gm.p2CoinWallet++;
                Destroy(this.gameObject);
            }
        }
    }

}

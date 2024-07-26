using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //REFERENCES//
    private GameManager gm; //Reference to GameManager for adjusting score of P1/P2 coins 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(other.gameObject.name == "Player1")
            {
                Debug.Log("Coin Collected");
                other.gameObject.GetComponent<PlayerMovement>().coinWallet++;
                Destroy(this.gameObject);
            }
            Debug.Log("Coin Collected");

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinBarrelCounter : MonoBehaviour
{
    public TextMeshProUGUI CoinDisplay;
    public int coinAmount; 

    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CoinDisplay.text = coinAmount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If Player 1's Moneybag touches this goal (if the GameObject is Moneybag) 

        //If Player 2's Moneybag touches this goal (if the GameObject is MoneybagP2)
        //Increase the p1CoinBarrel amount by the coinAmount from the Moneybag prefab 

        if (collision.gameObject.CompareTag("Moneybag"))
        {
            // read how many coins are in the moneybag and add that to the barrel's coin amount  
            //coinAmount += collision.gameObject.GetComponent("CoinCollecting").coinInventory;
        }
    }
}

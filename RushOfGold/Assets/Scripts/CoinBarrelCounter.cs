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
        if (collision.gameObject.CompareTag("Moneybag"))
        {
            // read how many coins are in the moneybag and add that to the barrel's coin amount  
            //coinAmount += collision.gameObject.GetComponent("CoinCollecting").coinInventory;
        }
    }
}

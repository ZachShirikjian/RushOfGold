using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBarrelCounter : MonoBehaviour
{

    public TMPro.TextMeshPro CoinDisplay;
    public int coinAmount; 

    // Start is called before the first frame update
    void Start()
    {
        
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

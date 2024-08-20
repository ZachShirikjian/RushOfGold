using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private GameManager gm;     //Reference to GameManager 
    public GameObject Coin; //coinprefab
    public float spawnInterval = 2.0f; // Time interval between spawns
    public float spawnAreaMinX = -10.0f; // Minimum X position for spawning
    public float spawnAreaMaxX = 10.0f; // Maximum X position for spawning
    public float spawnAreaMinY = 0.0f; // Minimum Y position for spawning
    public float spawnAreaMaxY = 5.0f; // Maximum Y position for spawning

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnCoins());
    }

    //Spawn coins only when the Game Timer is Running! 
    IEnumerator SpawnCoins()
    {
        while (true && gm.timeRunning == true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCoin()
    {
        float spawnX = Random.Range(spawnAreaMinX, spawnAreaMaxX);
        float spawnY = Random.Range(spawnAreaMinY, spawnAreaMaxY);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(Coin, spawnPosition, Quaternion.identity);
    }
}

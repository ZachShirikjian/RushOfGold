using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameManager gameManager; //Reference to GameManager script
    public GameObject coinPrefab; // Reference to the coin prefab
    public float spawnInterval = 2.0f; // Time interval between spawns
    public float spawnAreaMinX = -10.0f; // Minimum X position for spawning
    public float spawnAreaMaxX = 10.0f; // Maximum X position for spawning
    public float spawnAreaMinY = 0.0f; // Minimum Y position for spawning
    public float spawnAreaMaxY = 5.0f; // Maximum Y position for spawning

    void Start()
    {
        StartCoroutine(SpawnCoins());
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    IEnumerator SpawnCoins()
    {
        //Start spawning coins after the GameManager's countdown has finished (4 seconds)
        yield return new WaitForSeconds(4f);
        while (gameManager.timeRunning == true)
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
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
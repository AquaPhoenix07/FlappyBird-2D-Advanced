using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // ObjectPooling
    private Queue<GameObject> coinPool;
    private int poolSize = 2;
    public GameObject coinPrefab;
    // Spawn Setting
    private int coinSpawnRate = 5;
    private int spawnCount = 0;
    

    private void Start()
    {
        coinPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            
            MoveLeft coinMoveScript = coin.GetComponent<MoveLeft>();
            coinMoveScript.ObjectDespawned += ReturnCoin;
            
            Coin coinScript = coin.GetComponent<Coin>();
            coinScript.OnCoinReturn += ReturnCoin;
            
            coin.SetActive(false);
            coinPool.Enqueue(coin);
        }
        ObstaclesSpawner.PipeSpawn += CountAndSpawnCoin;
        
    }

    private GameObject GetCoin()
    {
        if (coinPool.Count > 0)
        {
            GameObject coin = coinPool.Dequeue();
            coin.SetActive(true);
            return coin;
        }
        else
        {
            GameObject coin = Instantiate(coinPrefab);
            
            MoveLeft coinMoveScript = coin.GetComponent<MoveLeft>();
            coinMoveScript.ObjectDespawned += ReturnCoin;
            
            Coin coinScript = coin.GetComponent<Coin>();
            coinScript.OnCoinReturn += ReturnCoin;
            return coin;
        }
    }

    private void ReturnCoin(GameObject coin)
    {
        coin.SetActive(false);
        coinPool.Enqueue(coin);
    }

    private void CountAndSpawnCoin(Vector3 spawnPos)
    {
        spawnCount++;
        if (spawnCount == coinSpawnRate)
        {
            SpawnCoin(spawnPos);
            spawnCount = 0;
        }
    }
    private void SpawnCoin(Vector3 spawnPos)
    {
        GameObject coin = GetCoin();
        float yOffset = -2f; // Do pivot của pile bị lệch
        coin.transform.position = new Vector3(spawnPos.x, spawnPos.y + yOffset, 0);
    }

    private void OnDestroy()
    {
        ObstaclesSpawner.PipeSpawn -= CountAndSpawnCoin;
    }
}

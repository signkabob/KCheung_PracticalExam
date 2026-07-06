using UnityEngine;

/**
 * Midterm Exam - CoinSpawner.cs
 * Name: Ka Bo Cheung
 * Date: 07/06/2026
 * Course: GAME-2341-001
 * 
 * Script for the coin spawner
 * Note: Refer to EnemeySpawner.cs from UtsabKDas
 */
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] coinPrefabs;
    [SerializeField] private int numOfSpawnStart = 5;
    [SerializeField] private float repeatRate = 3f;
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private float maxBound = 45.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numOfSpawnStart; i++)
        {
            SpawnCoin();
        }

        InvokeRepeating("SpawnCoin", spawnDelay, repeatRate);
    }

    /// <summary>
    /// Spawns a random coin from bronze, silver, or gold at random position within the room
    /// </summary>
    private void SpawnCoin()
    {
        GameObject spawnedCoin = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(-maxBound, maxBound), spawnedCoin.transform.position.y, Random.Range(-maxBound, maxBound));
        Instantiate(spawnedCoin, spawnPosition, spawnedCoin.transform.rotation);
    }

    /// <summary>
    /// Stops spawning coins
    /// </summary>
    public void StopSpawnCoin()
    {
        CancelInvoke();
    }
}

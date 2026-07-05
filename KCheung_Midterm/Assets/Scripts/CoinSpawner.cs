using UnityEngine;

// Refer to EnemeySpawner.cs from UtsabKDas
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCoin()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-maxBound, maxBound), 0, Random.Range(-maxBound, maxBound));
        GameObject spawnedCoin = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
        Instantiate(spawnedCoin, spawnPosition, spawnedCoin.transform.rotation);
    }
}

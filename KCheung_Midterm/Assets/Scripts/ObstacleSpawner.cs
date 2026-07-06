using UnityEngine;

// Refer to EnemeySpawner.cs from UtsabKDas
public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform[] spawnPoints;
    
    [SerializeField] private int numOfSpawn = 0;
    [SerializeField] private int maxNumOfSpawn = 15;
    [SerializeField] private float repeatRate = 3f;
    [SerializeField] private float spawnDelay = 5f;

    private bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        if (numOfSpawn < maxNumOfSpawn)
        {
            Transform spawnedPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(obstaclePrefab, new Vector3(spawnedPoint.position.x, obstaclePrefab.transform.position.y, spawnedPoint.position.z), obstaclePrefab.transform.rotation);
            numOfSpawn += 1;
        }
    }

    public void ReplaceDestroyedObstacle()
    {
        numOfSpawn -= 1;
        if (!gameOver)
        {
            SpawnObstacle();

        }
    }

    public void StopSpawnObstacle()
    {
        gameOver = true;
        CancelInvoke();
    }
}

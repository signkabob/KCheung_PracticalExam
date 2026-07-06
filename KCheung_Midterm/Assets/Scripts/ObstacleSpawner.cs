using UnityEngine;

/**
 * Midterm Exam - ObstacleSpawner.cs
 * Name: Ka Bo Cheung
 * Date: 07/06/2026
 * Course: GAME-2341-001
 * 
 * Script for the obstacle spawner
 * Note: Refer to EnemeySpawner.cs from UtsabKDas
 */
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

    /// <summary>
    /// Spawns the obstacle at one of the random spawn points unless the max number of spawns in the scene is reached
    /// </summary>
    private void SpawnObstacle()
    {
        if (numOfSpawn < maxNumOfSpawn)
        {
            Transform spawnedPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(obstaclePrefab, new Vector3(spawnedPoint.position.x, obstaclePrefab.transform.position.y, spawnedPoint.position.z), obstaclePrefab.transform.rotation);
            numOfSpawn += 1;
        }
    }

    /// <summary>
    /// Spawns the new obstacle when the previous one gets destroyed unless the game is over
    /// </summary>
    public void ReplaceDestroyedObstacle()
    {
        numOfSpawn -= 1;
        if (!gameOver)
        {
            SpawnObstacle();

        }
    }

    /// <summary>
    /// Stops spawning obstacles and call for the game over state
    /// </summary>
    public void StopSpawnObstacle()
    {
        gameOver = true;
        CancelInvoke();
    }
}

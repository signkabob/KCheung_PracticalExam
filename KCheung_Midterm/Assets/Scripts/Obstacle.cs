using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Midterm Exam - Obstacle.cs
 * Name: Ka Bo Cheung
 * Date: 07/06/2026
 * Course: GAME-2341-001
 * 
 * Script for the obstacle movement and interactions
 */
public class Obstacle : MonoBehaviour
{
    private Rigidbody rb;
    private ObstacleSpawner obstacleSpawner;
    private int wallLayer;

    [SerializeField] private int damage;
    [SerializeField] private float minSpeed = 5;
    [SerializeField] private float maxSpeed = 15;
    [SerializeField] private int minDamage = 1;
    [SerializeField] private int maxDamage = 5;

    private float maxBound = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        obstacleSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        wallLayer = LayerMask.NameToLayer("Wall");
        
        // Generate random damage, random speed, and random direction
        damage = Random.Range(minDamage, maxDamage + 1);
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        float randomX = Random.Range(-maxBound, maxBound);
        float randomZ = Random.Range(-maxBound, maxBound);
        Vector3 randomDirection = new Vector3(randomX, 0.0f, randomZ).normalized;

        rb.linearVelocity = randomDirection * randomSpeed;
    }

    /// <summary>
    /// Detects trigger collisions
    /// </summary>
    /// <param name="other">Collider</param>
    private void OnTriggerEnter(Collider other)
    {
        // If the obstacle hits the wall, destroy the obstacle and call for a new spawn
        if (other.gameObject.layer == wallLayer)
        {
            obstacleSpawner.ReplaceDestroyedObstacle();
            Destroy(gameObject);
        }

        // Similar to the wall detection but dealt damage to the player in addition
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            obstacleSpawner.ReplaceDestroyedObstacle();
            Destroy(gameObject);
        }
    }
}

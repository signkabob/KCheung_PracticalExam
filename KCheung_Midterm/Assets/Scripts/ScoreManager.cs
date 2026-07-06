using UnityEngine;

/**
 * Midterm Exam - ScoreManger.cs
 * Name: Ka Bo Cheung
 * Date: 07/06/2026
 * Course: GAME-2341-001
 * 
 * Script for the game maanger to keep track of the score and game state
 */
public class ScoreManager : MonoBehaviour
{
    private CoinSpawner coinSpawner;
    private ObstacleSpawner obstacleSpawner;

    [SerializeField] private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinSpawner = GameObject.Find("CoinSpawner").GetComponent<CoinSpawner>();
        obstacleSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        Debug.Log("SCORE: " + score);
    }

    /// <summary>
    /// Adds the points to the current score
    /// </summary>
    /// <param name="points">Score points gained from obtaining the coin</param>
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("SCORE: " + score);

        // If the score reaches 50 points, then the player wins
        if (score >= 50)
        {
            Victory();
        }
    }

    /// <summary>
    /// Calls for the victory message and the game over state
    /// </summary>
    private void Victory()
    {
        Debug.Log("You win!");
        GameOver();
    } 

    /// <summary>
    /// Calls for the loss message and the game over state
    /// </summary>
    public void Loss()
    {
        Debug.Log("You lose!");
        GameOver();
    }

    /// <summary>
    /// Stops the game and spawnings
    /// </summary>
    public void GameOver()
    {
        coinSpawner.StopSpawnCoin();
        obstacleSpawner.StopSpawnObstacle();
    }
}

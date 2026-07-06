using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("SCORE: " + score);
        if (score >= 50)
        {
            Victory();
        }
    }

    private void Victory()
    {
        Debug.Log("You win!");
        GameOver();
    } 

    public void Loss()
    {
        Debug.Log("You lose!");
        GameOver();
    }

    public void GameOver()
    {
        coinSpawner.StopSpawnCoin();
        obstacleSpawner.StopSpawnObstacle();
    }
}

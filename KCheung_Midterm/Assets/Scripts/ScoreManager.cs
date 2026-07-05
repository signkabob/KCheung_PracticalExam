using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
    } 

    public void GameOver()
    {
        
    }

    
}

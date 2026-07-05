using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] private int health = 20;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            scoreManager.DeadPlayer();
        }
    }
}

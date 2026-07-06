using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private ScoreManager scoreManager;
    [SerializeField] private int health = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GetComponent<PlayerController>().DeadPlayer();
            scoreManager.Loss();
        }
    }
}

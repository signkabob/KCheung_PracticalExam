using UnityEngine;

/**
 * Midterm Exam - PlayerHealth.cs
 * Name: Ka Bo Cheung
 * Date: 07/06/2026
 * Course: GAME-2341-001
 * 
 * Script for the player health record
 */
public class PlayerHealth : MonoBehaviour
{
    private ScoreManager scoreManager;
    [SerializeField] private int health = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    /// <summary>
    /// Loses healh points
    /// </summary>
    /// <param name="damage">Damage points dealt to the player health</param>
    public void TakeDamage(int damage)
    {
        health -= damage;

        // If the player loses all health, stop their movement and call for game loss
        if (health <= 0)
        {
            GetComponent<PlayerController>().DeadPlayer();
            scoreManager.Loss();
        }
    }
}

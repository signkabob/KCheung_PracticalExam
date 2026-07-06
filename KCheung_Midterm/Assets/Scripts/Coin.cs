using UnityEngine;

public class Coin : MonoBehaviour
{
    private ScoreManager scoreManager;
    private bool moveUp = true;

    [SerializeField] private int points;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotateSpeed = 90;
    [SerializeField] private float minY = 0.5f;
    [SerializeField] private float maxY = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // The coin's local x-axis is upward due to its predetermined rotation.
        // Rotate around the local x-axis
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
        
        // Move up and down through the local x-axis
        if (moveUp)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);  
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        // Move the other way after reaching the bound 
        if (transform.position.y >= maxY)
        {
            moveUp = false;
        } 
        else if (transform.position.y <= minY)
        {
            moveUp = true;
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scoreManager.AddScore(points);
            Destroy(gameObject);
        }
    }
}

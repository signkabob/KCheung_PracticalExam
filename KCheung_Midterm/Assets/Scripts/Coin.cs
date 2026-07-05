using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int points;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotateSpeed = 30;
    [SerializeField] private float minY = 0.5f;
    [SerializeField] private float maxY = 1.5f;
    [SerializeField] private bool moveUp = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

        // Should be rotating around y-axis; something's wrong with its local or world rotation
        // transform.Rotate(transform.rotation.x, rotateSpeed * Time.deltaTime, transform.rotation.z);

        
        // Moving up and down 
        if (moveUp)
        {
            transform.Translate(-transform.up * moveSpeed * Time.deltaTime);
           
        }
        else
        {
            transform.Translate(transform.up * moveSpeed * Time.deltaTime);
        }

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

using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotateSpeed = 60;
    [SerializeField] private float minY = 0.5f;
    [SerializeField] private float maxY = 2.5f;
    [SerializeField] private bool moveUp = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Should be rotating around y-axis
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotateSpeed * Time.deltaTime, transform.rotation.y);
        
        // Moving up and down 
        if (moveUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= maxY)
            {
                moveUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= minY)
            {
                moveUp = true;
            }
        }
        
        
    }
}

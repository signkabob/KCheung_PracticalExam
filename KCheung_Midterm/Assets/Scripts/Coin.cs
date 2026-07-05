using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private float rotateSpeed = 30;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotateSpeed * Time.deltaTime, transform.rotation.z);
    }
}

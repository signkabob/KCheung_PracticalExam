using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 40f;
    [SerializeField] private float bulletLifeTime = 5f;
    [SerializeField] private int damage = 1;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        
        Destroy(gameObject, bulletLifeTime);
    }
    
    public int GetDamage()
    {
        return damage;
    }
}

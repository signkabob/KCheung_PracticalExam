using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Camera camera;
    private Transform cameraTransform;

    public GameObject bulletPrefab;

    [SerializeField] private float speed = 12.0f;
    [SerializeField] private int rotationSpeed = 12;
    [SerializeField] private float jumpForce = 9.0f;
    [SerializeField] private bool isGrounded = true;
    private Vector3 finalMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        camera = cameraTransform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void FixedUpdate()
    {
        HandleJump();
        rb.AddForce(finalMove, ForceMode.Force);
    }

    private void HandleMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float forwardMovement = Input.GetAxis("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 cameraRelativeMoveDirection = ((cameraRight * horizontalMovement) + (cameraForward * forwardMovement)).normalized;

        if (cameraRelativeMoveDirection.sqrMagnitude > .001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraRelativeMoveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        finalMove = cameraRelativeMoveDirection * speed;
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

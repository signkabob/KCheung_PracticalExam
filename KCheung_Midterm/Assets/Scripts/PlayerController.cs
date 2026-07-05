using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Camera camera;
    private Transform cameraTransform;

    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private float rotateSpeed = 12f;
    [SerializeField] private float jumpForce = 5;
    
    private bool isGrounded = true;
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
    }

    void FixedUpdate()
    {
        HandleJump();
        rb.AddForce(finalMove, ForceMode.Force);
    }

    private void HandleMovement()
    {
        // Refer to ThirdPersonPhysicsMovement.cs from UtsabKDas 
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        // TODO: Stop ice sliding later 

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 cameraRelativeMoveDirection = ((cameraRight * moveX) + (cameraForward * moveZ)).normalized;

        if (cameraRelativeMoveDirection.sqrMagnitude > .001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraRelativeMoveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        
        finalMove = cameraRelativeMoveDirection * moveSpeed;
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

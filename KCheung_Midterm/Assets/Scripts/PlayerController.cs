using UnityEngine;

/**
 * Midterm Exam - PlayerController.cs
 * Name: Ka Bo Cheung
 * Date: 07/06/2026
 * Course: GAME-2341-001
 * 
 * Script for the player input movement, physics simulations, and interactions
 */
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Transform cameraTransform;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotateSpeed = 12f;
    [SerializeField] private float jumpForce = 20;
    
    private bool isGrounded = true;
    private Vector3 finalMove;
    private bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            CalculateMovement();
        }
    }

    void FixedUpdate()
    {
        if (!gameOver)
        {
            HandleJump();
            HandleMovement();
        }
    }

    /// <summary>
    /// Calculates the movement vector from the camera view based on the inputs
    /// Note: Refer to ThirdPersonPhysicsMovement.cs from UtsabKDas 
    /// </summary>
    private void CalculateMovement()
    {
        finalMove = Vector3.zero;   
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        
        // If no input, then no need to calculate the vector
        if ((moveX != 0.0f) || (moveZ != 0.0f))
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 cameraRight = cameraTransform.right;
            cameraForward.y = 0f;
            cameraRight.y = 0f;

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
    }

    /// <summary>
    /// Handles jumping phsyics simulations
    /// </summary>
    private void HandleJump()
    {
        // Jump if the player is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    /// <summary>
    /// Handles movement physics simulations 
    /// Note: Player's linear damping is 4 to increase fiction and prevent sliding
    /// </summary>
    private void HandleMovement()
    {
        // Move the player immediately without acceralation and time
        if (finalMove != Vector3.zero)
        {
            rb.AddForce(finalMove, ForceMode.VelocityChange);
        }
        // Eliminate any velocity to force-stop the non y-axis movement
        else
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }
    }

    /// <summary>
    /// Detects collisions with other rigidbody objects
    /// </summary>
    /// <param name="other">Collider</param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    } 

    /// <summary>
    /// Calls for the game over state and stops the player movement when the health is zero
    /// </summary>
    public void DeadPlayer()
    {
        gameOver = true;
    }
}

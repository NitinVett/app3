using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 6f;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
    }

    void FixedUpdate()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = (transform.right * x + transform.forward * z).normalized;
        Vector3 move = direction * moveSpeed;

        
        Vector3 velocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        rb.linearVelocity = velocity;
    }
}
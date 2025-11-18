using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float health = 100;
    public float moveSpeed = 6f;
    public float jumpForce = 7f;

    public Enemy enemy;
    public GameObject weapon;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }
    void Update()
    {
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("enemy");
        Debug.Log(layerMask);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Did Hit");
                Enemy zombie = hit.collider.GetComponent<Enemy>();
                zombie.TakeDamage(100);
                
            }
        }
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
    void OnTriggerStay(Collider other)
    {
        enemy = other.gameObject.GetComponent<Enemy>();
        if (other.gameObject.tag == "Enemy" && enemy.attackCooldown == 0f )
        {
            TakeDamage(enemy.damage);
            enemy.attackCooldown = 3f;
        }
    }
    public void TakeDamage(float damageAmount)
    {
        if(health > 0)
        {
            health -= damageAmount;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void HealHealth(float healAmount)
    {   
        health += healAmount;
    }
}
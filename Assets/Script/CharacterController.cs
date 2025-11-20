using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float health = 100;
    public float moveSpeed = 6f;
    public float jumpForce = 7f;
    public float pickupDistance = 5;

    private Enemy enemy;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapWeapon();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
       
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("enemy");
        Debug.Log(layerMask);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
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
    public void SwapWeapon()
    {
        CharacterInventory inventory = gameObject.GetComponent<CharacterInventory>();
        if(inventory.holdingSlot == 1&& inventory.slot2 != null)
        {
            inventory.holdingSlot = 2;
        }
        else if(inventory.holdingSlot == 2)
        {
            inventory.holdingSlot = 1;
        }
    }
    public void Pickup()
    {
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("item");
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance, layerMask))
            {
                CharacterInventory inventory = gameObject.GetComponent<CharacterInventory>();
                GameObject item = hit.collider.gameObject;

                if(inventory.holdingSlot == 1 && inventory.slot2 == null)
                {
                    inventory.slot2 = item;
                }
                else if(inventory.holdingSlot == 1 && inventory.slot2 != null)
                {
                    inventory.slot1 = item;
                }
                else if(inventory.holdingSlot == 2)
                {
                    inventory.slot2 = item;
                }
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
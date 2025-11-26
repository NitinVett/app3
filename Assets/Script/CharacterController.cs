using UnityEngine;
using TMPro;
public class CharacterController : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public float moveSpeed = 3f;
    public float sprintSpeed = 6f;
    public float pickupDistance = 50;
    public Camera fpsCam;
    private Enemy enemy;
    private Rigidbody rb;
    CharacterInventory inventory;
    public TMP_Text HealthGUI;

    void Start()
    {
        inventory = gameObject.GetComponent<CharacterInventory>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwapWeapon();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
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
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 velocity = new Vector3(direction.x * sprintSpeed, rb.linearVelocity.y, direction.z * sprintSpeed);
            rb.linearVelocity = velocity;
        }
        else
        {
            Vector3 velocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);
            rb.linearVelocity = velocity;
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

        HealthGUI.text = $"{health}/{maxHealth}";
    }
    public void HealHealth(float healAmount)
    {   
        health += healAmount;
    }
    public void SwapWeapon()
    {
        inventory.swapWeapons();
        
    }
    public void Pickup()
    {
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("item");
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, pickupDistance, layerMask))
        {
            CharacterInventory inventory = gameObject.GetComponent<CharacterInventory>();
            GameObject item = hit.collider.gameObject;
            inventory.pickup(item.tag);
            item.SetActive(false);
        }
    }
}
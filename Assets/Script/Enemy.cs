using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float damage = 20;
    public Transform player;
    private NavMeshAgent agent;
    public float attackCooldown = 0;
    public Animation anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            agent.SetDestination(player.position);
            anim.Play();
        }
        
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakeDamage(20);
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
}

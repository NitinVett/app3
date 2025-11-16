using UnityEngine;
using UnityEngine.AI;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;
    public Transform player;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            agent.SetDestination(player.position);
        }
    }
}

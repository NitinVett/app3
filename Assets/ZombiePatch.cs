using UnityEngine;

public class ZombiePatch : MonoBehaviour
{
    public GameObject zombiePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnZombie()
    {
        Instantiate(zombiePrefab, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
    }
}

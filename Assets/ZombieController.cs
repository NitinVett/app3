using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    ZombiePatch[] patches;
    void Start()
    {
        patches = new ZombiePatch[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            patches[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<ZombiePatch>();
        }
        StartCoroutine(spawnZombies());
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnZombies()
    {
        
        for(int i = 0; i < 25; i++)
        {
            
            int r = Random.Range(0,patches.Length);
            patches[r].spawnZombie();
            yield return new WaitForSeconds(1f);
        }
        
        
        
        
    }
}

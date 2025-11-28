using UnityEngine;
using System.Collections;
using TMPro;


public class ZombieController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    ZombiePatch[] patches;
    public Transform zombieFolder;
    int rounds = 0;
    public TMP_Text roundGUI;
    void Start()
    {
        patches = new ZombiePatch[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            patches[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<ZombiePatch>();
        }
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if(zombieFolder.childCount == 0)
        {
            rounds += 1;
            
            roundGUI.text = rounds.ToString();
            StartCoroutine(spawnZombies());
        }
    }

    IEnumerator spawnZombies()
    {
        
        for(int i = 0; i < rounds*5; i++)
        {
            
            int r = Random.Range(0,patches.Length);
            patches[r].spawnZombie();
            yield return new WaitForSeconds(1f);
        }
        
        
        
        
    }
}

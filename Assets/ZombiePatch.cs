using UnityEngine;

public class ZombiePatch : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform zombieFolder;

    public void spawnZombie()
    {
        Instantiate(zombiePrefab, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity,zombieFolder);
    }
}

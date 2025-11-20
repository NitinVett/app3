using UnityEngine;
using DG.Tweening;
public class door_open : MonoBehaviour
{
    public GameObject door;
    
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        door.transform.DORotate(
            new Vector3(90, 90, 0), 
            1f                     
        );
        gameObject.SetActive(false);
    }
    
}



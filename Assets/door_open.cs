using UnityEngine;
using DG.Tweening;
public class door_open : MonoBehaviour
{
    public GameObject door;
    public GameObject open_prompt;
    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        open_prompt.SetActive(true);
         if (Input.GetKey(KeyCode.E))
        {
            door.transform.DORotate(new Vector3(90, 90, 0), 1f);
            gameObject.SetActive(false);
            open_prompt.SetActive(false);
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        open_prompt.SetActive(false);
    }

}



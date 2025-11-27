using UnityEngine;
using DG.Tweening;
public class door_open : MonoBehaviour
{
    public GameObject door;
    public GameObject open_prompt;

    void OnTriggerStay(Collider other)
    {
        open_prompt.SetActive(true);
        CharacterInventory player = other.gameObject.GetComponent<CharacterInventory>();
        
         if (Input.GetKey(KeyCode.E) && player.money >= 100)
        {
            door.transform.DOLocalRotate(new Vector3(0, door.transform.localEulerAngles.y + 90, 0), 1f);
            gameObject.SetActive(false);
            open_prompt.SetActive(false);
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        open_prompt.SetActive(false);
    }

}



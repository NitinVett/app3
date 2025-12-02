using UnityEngine;
using DG.Tweening;
public class door_open : MonoBehaviour
{
    public GameObject door;
    public GameObject open_prompt;
    public int cost;
    void OnTriggerStay(Collider other)
    {
        open_prompt.SetActive(true);
        CharacterInventory player = other.gameObject.GetComponent<CharacterInventory>();
        
         if (Input.GetKey(KeyCode.E) && player.money >= cost)
        {
            
            door.transform.DOLocalRotate(new Vector3(90, door.transform.localEulerAngles.y, 0), 1f);
            gameObject.SetActive(false);
            open_prompt.SetActive(false);
            player.money -=cost;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        open_prompt.SetActive(false);
    }

}



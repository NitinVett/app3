using UnityEngine;
using DG.Tweening;
public class VendingMachine : MonoBehaviour
{
    public GameObject vendingMachine;
    public GameObject prompt;
    public int cost = 500;

    void OnTriggerStay(Collider other)
    {
        prompt.SetActive(true);
        CharacterInventory inventory = other.gameObject.GetComponent<CharacterInventory>();
        
         if (Input.GetKey(KeyCode.E) && inventory.money >= cost)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(vendingMachine.transform.DOMoveY(transform.position.y+2,1f));
            sequence.Append(vendingMachine.transform.DOMoveY(transform.position.y,1f));
            inventory.money-=cost;
            CharacterController player = other.gameObject.GetComponent<CharacterController>();
            if(vendingMachine.name == "CoffeeSprintMachine"){
                player.sprintSpeed +=1;
            }
            else if (vendingMachine.name == "FoodHealthMachine")
            {
                player.maxHealth = 200;
            }
            else if(vendingMachine.name == "SodaMoveMachine")
            {
                player.moveSpeed +=1;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        prompt.SetActive(false);
    }
}



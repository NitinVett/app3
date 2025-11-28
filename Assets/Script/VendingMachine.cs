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
        if (Input.GetKeyDown(KeyCode.E) && inventory.money >= cost)
        {
            bool bought = false; 
            if(vendingMachine.name == "CoffeeSprintMachine")
            {
                bought = inventory.BuyPerk("Coffee", cost);
            }
            else if (vendingMachine.name == "FoodHealthMachine")
            {
                bought = inventory.BuyPerk("Food", cost);
            }
            else if(vendingMachine.name == "SodaMoveMachine")
            {
                bought = inventory.BuyPerk("Soda", cost);
            }                
            if (bought)
            {
            PlayBounceAnimation();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        prompt.SetActive(false);
    }
    void PlayBounceAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(vendingMachine.transform.DOMoveY(transform.position.y + 2, 1f));
        sequence.Append(vendingMachine.transform.DOMoveY(transform.position.y, 1f));
    }
}



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
            CharacterController player = other.gameObject.GetComponent<CharacterController>();
            if(vendingMachine.name == "CoffeeSprintMachine")
            {
                inventory.BuyPerk("Coffee", cost);
                PlayBounceAnimation();

            }
            else if (vendingMachine.name == "FoodHealthMachine")
            {
                inventory.BuyPerk("Food", cost);
                PlayBounceAnimation();

            }
            else if(vendingMachine.name == "SodaMoveMachine")
            {
                inventory.BuyPerk("Soda", cost);
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



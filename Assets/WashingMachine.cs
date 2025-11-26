using UnityEngine;
using DG.Tweening;

public class WashingMachine : MonoBehaviour
{
    public GameObject washingMachine;
    public GameObject buyPrompt;
    public GameObject takePrompt;

    public int cost = 1000;
    private bool purchased = false;
    private GameObject depositedWeapon;

    void OnTriggerStay(Collider other)
    {
        CharacterInventory inventory = other.GetComponent<CharacterInventory>();

        if (!purchased)
        {
            buyPrompt.SetActive(true);
            takePrompt.SetActive(false);

            if (Input.GetKeyDown(KeyCode.E) && inventory.money >= cost)
            {
                purchased = true;
                inventory.money -= cost;

                buyPrompt.SetActive(false);
                takePrompt.SetActive(true);

                float startY = washingMachine.transform.position.y;

                Sequence sequence = DOTween.Sequence();
                sequence.Append(washingMachine.transform.DOMoveY(startY + 2, 1f));
                sequence.Append(washingMachine.transform.DOMoveY(startY, 1f));

                if (inventory.holdingSlot == 1)
                {
                    depositedWeapon = inventory.slot1;
                    depositedWeapon.GetComponent<MeleeWeapons>().Upgrade();
                    depositedWeapon.SetActive(false);
                }
                else if (inventory.holdingSlot == 2)
                {
                    depositedWeapon = inventory.slot2;
                    depositedWeapon.GetComponent<MeleeWeapons>().Upgrade();
                    depositedWeapon.SetActive(false);
                }
            }
        }
        else
        {
            buyPrompt.SetActive(false);
            takePrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (depositedWeapon != null)
                {
                    depositedWeapon.SetActive(true);
                    depositedWeapon = null;
                }

                purchased = false;
                takePrompt.SetActive(false);
                buyPrompt.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        buyPrompt.SetActive(false);
        takePrompt.SetActive(false);
    }
}

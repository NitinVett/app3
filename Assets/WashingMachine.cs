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
    private GameObject weapomInMachine;    
    public Transform machineWeaponsFolder;        
    private GameObject[] machineWeapons;
    public int lastSlotHeld;


    void Start()
    {
        // Load all machine weapon models into array
        machineWeapons = new GameObject[machineWeaponsFolder.childCount];

        for (int i = 0; i < machineWeaponsFolder.childCount; i++)
        {
            machineWeapons[i] = machineWeaponsFolder.GetChild(i).gameObject;
        }
    }



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

                // Get the weapon the player is holding
                if (inventory.holdingSlot == 1)
                    {
                    lastSlotHeld = 1;
                    depositedWeapon = inventory.slot1;
                    inventory.slot1 = null;
                    }
                else{
                    lastSlotHeld = 2;
                    depositedWeapon = inventory.slot2;
                    inventory.slot2 = null;
                    }


                // Upgrade the player's real weapon
                depositedWeapon.GetComponent<MeleeWeapons>().Upgrade();

                // Disable weapon in player's hand
                depositedWeapon.SetActive(false);

                // Find the matching machine model
                foreach (GameObject w in machineWeapons)
                {
                    if (w.name == depositedWeapon.name)
                    {
                        Debug.Log(w.name);
                        Debug.Log(depositedWeapon.name);

                        weapomInMachine = w;
                        weapomInMachine.SetActive(true);
                        break;
                    }
                }
            }
        }
        else
        {
            buyPrompt.SetActive(false);
            takePrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Return weapon to player
                if (depositedWeapon != null)
                {
                    depositedWeapon.SetActive(true);
                    if (lastSlotHeld == 1)
                    {
                        inventory.slot1 = depositedWeapon;
                    }
                    else
                    {
                        inventory.slot2 = depositedWeapon;
                    }
                }
                    
                // Hide weapon inside machine
                if (weapomInMachine != null){
                    weapomInMachine.SetActive(false);
                }

                depositedWeapon = null;
                weapomInMachine = null;
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

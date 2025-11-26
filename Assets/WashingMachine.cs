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
    private GameObject depositedWeaponMachine;    
    public Transform machineWeaponsFolder;        
    private GameObject[] machineWeapons;


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
                    depositedWeapon = inventory.slot1;
                else
                    depositedWeapon = inventory.slot2;

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

                        depositedWeaponMachine = w;
                        depositedWeaponMachine.SetActive(true);
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
                    depositedWeapon.SetActive(true);

                // Hide weapon inside machine
                if (depositedWeaponMachine != null)
                    depositedWeaponMachine.SetActive(false);

                depositedWeapon = null;
                depositedWeaponMachine = null;

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

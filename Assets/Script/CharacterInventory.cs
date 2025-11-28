using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class CharacterInventory : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public int holdingSlot;
    public GameObject knife;
    public GameObject hockeystick;
    public GameObject axe;
    public GameObject ak47;
    public int money;
    public TMP_Text MoneyGUI;
    public TMP_Text WeaponNameGUI;
    public RawImage CoffeePerkGUI;
    public RawImage SodaPerkGUI;
    public RawImage FoodPerkGUI;

    public bool hasFoodPerk = false;
    public bool hasSodaPerk = false;
    public bool hasCoffeePerk = false;

    private Dictionary<string, (Vector3 pos, Quaternion rot)> weaponTransforms =
    new Dictionary<string, (Vector3 pos, Quaternion rot)>();

    void Start()
   {
        weaponTransforms.Add("knife", (knife.transform.localPosition, knife.transform.localRotation));
        weaponTransforms.Add("axe", (axe.transform.localPosition, axe.transform.localRotation));
        weaponTransforms.Add("hockeystick", (hockeystick.transform.localPosition, hockeystick.transform.localRotation));
        weaponTransforms.Add("ak47", (ak47.transform.localPosition, ak47.transform.localRotation));
        money = 0;
        holdingSlot = 1;
        slot1 = knife;
        slot2 = null;
        knife.SetActive(true);
    }
    void Update()
    {
        if (holdingSlot == 1)
        {
            WeaponNameGUI.text = $"{slot1.name}";
        }
        else if (holdingSlot == 2)
        {
            WeaponNameGUI.text = $"{slot2.name}";
        }
        MoneyGUI.text = $"${money}";
    }

    GameObject itemNameToItem(string itemName)
    {
        if (itemName == "axe") return axe;
        if (itemName == "hockeystick") return hockeystick;
        if (itemName == "knife") return knife;
        if (itemName == "ak47") return ak47;
        return null;
    }

    void SetWeaponTransform(GameObject weapon)
    {
        var t = weaponTransforms[weapon.tag];
        weapon.transform.SetLocalPositionAndRotation(t.pos, t.rot);
    }

    public void pickup(string itemName)
    {
        GameObject item = itemNameToItem(itemName);
        if (item == null) return;

        if (holdingSlot == 1 && slot2 == null)
        {
            slot1.SetActive(false);
            slot2 = item;
            holdingSlot = 2;
            SetWeaponTransform(slot2);
            slot2.SetActive(true);
        }
        else if (holdingSlot == 1 && slot2 != null)
        {
            slot1.SetActive(false);
            slot1 = item;
            holdingSlot = 1;
            SetWeaponTransform(slot1);
            slot1.SetActive(true);
        }
        else if (holdingSlot == 2)
        {
            slot2.SetActive(false);
            slot2 = item;
            holdingSlot = 2;
            SetWeaponTransform(slot2);
            slot2.SetActive(true);
        }
    }
    public void swapWeapons()
    {
        if (holdingSlot == 1 && slot2 != null)
        {
            slot1.SetActive(false);
            holdingSlot = 2;
            SetWeaponTransform(slot2);
            slot2.SetActive(true);
        }
        else if (holdingSlot == 2)
        {
            slot2.SetActive(false);
            holdingSlot = 1;
            SetWeaponTransform(slot1);
            slot1.SetActive(true);
        }
    }
    public bool BuyPerk(string perk, int cost)
    {
        CharacterController player = gameObject.GetComponent<CharacterController>();
            if(perk == "Coffee" && hasCoffeePerk == false)
            {
                player.sprintSpeed +=2;
                money -= cost;
                hasCoffeePerk = true;
                CoffeePerkGUI.gameObject.SetActive(true);
                return true;
            }
            else if (perk == "Food" && hasFoodPerk == false)
            {
                player.maxHealth = 200;
                money -= cost;
                hasFoodPerk = true;
                FoodPerkGUI.gameObject.SetActive(true);
                return true;
            }
            else if(perk == "Soda" && hasSodaPerk == false)
            {
                player.moveSpeed +=1;
                money -= cost;
                hasSodaPerk = true;
                SodaPerkGUI.gameObject.SetActive(true);
                return true;
            }
        return false;
    }
}

using System;
using JetBrains.Annotations;
using UnityEngine;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 0;
        holdingSlot = 1;
        slot1 = knife;
        slot2 = null;
        knife.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private GameObject itemNameToItem(String itemName)
    {
        if(itemName == "axe")
        {
            return axe;
        } else if(itemName == "hockeystick")
        {
            return hockeystick;
        } else if(itemName == "knife")
        {
            return knife;
        }else if(itemName == "ak47")
        {
            return ak47;
        }
        return null;
    }
    public void pickup(String itemName)
    {
        
        GameObject item = itemNameToItem(itemName);
        // put in slot 2
        if(holdingSlot == 1 && slot2 == null)
        {
            slot1.SetActive(false);
            slot2 = item;
            holdingSlot = 2;
            slot2.SetActive(true);
        }
        // put in slot 1
        else if(holdingSlot == 1 && slot2 != null)
        {
            slot1.SetActive(false);
            slot1 = item;
            holdingSlot = 1;
            slot1.SetActive(true);
        }
        // put in slot 2
        else if(holdingSlot == 2)
        {
            slot2.SetActive(false);
            slot2 = item;
            holdingSlot = 2;
            slot2.SetActive(true);
        }
        
        
    }
}

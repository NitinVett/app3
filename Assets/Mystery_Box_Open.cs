using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;


public class Mystery_Box_Open : MonoBehaviour
{
    
    public GameObject open_prompt;
    public GameObject pickup_prompt;
    private Transform lid;
    GameObject[] weapons;
    bool opened = false;
    bool pickup = false;
    bool inRange = false;
    CharacterInventory Player;
    GameObject activeWeapon;
    void Start()
    {
        
        Transform parent = transform.parent;
        Transform weaponHolder = parent.Find("Weapons");  
        lid = parent.transform.Find("Lid");

        
        weapons = new GameObject[weaponHolder.childCount];

        for (int i = 0; i < weaponHolder.childCount; i++)
        {
            weapons[i] = weaponHolder.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if(inRange){
            if(pickup == true)
            {
                pickup_prompt.SetActive(true);
            }
            if(!opened && ! pickup)
            {
                open_prompt.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E) && !opened && !pickup)
            {
                opened = true;
                lid.DORotate(new Vector3(-45, -180, 0), 1f);
                open_prompt.SetActive(false);
                StartCoroutine(CycleWeapons());
                
            }
            if (Input.GetKeyDown(KeyCode.E) && pickup)
            {
                opened = false;
                pickup = false;
                Player.pickup(activeWeapon.tag);
                activeWeapon.SetActive(false);
                lid.DORotate(new Vector3(0, -180, 0), 1f);
                pickup_prompt.SetActive(false);
                
            }
        }
        else
        {
            open_prompt.SetActive(false);
            pickup_prompt.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        Player = other.gameObject.GetComponent<CharacterInventory>();
        inRange = true;
        
    }

    IEnumerator CycleWeapons()
    {
        GameObject currWeapon = weapons[0];
            for(int i = 0; i < 10; i++)
            {
                currWeapon.SetActive(false);
                int r = UnityEngine.Random.Range(0,weapons.Length);
                currWeapon = weapons[r];
                currWeapon.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
        activeWeapon = currWeapon;
        pickup = true;
        
        
        
    }




    void OnTriggerExit(Collider other)
    {
        
        inRange = false;
    }

}



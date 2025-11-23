using UnityEngine;
using DG.Tweening;
using System.Collections;


public class Mystery_Box_Open : MonoBehaviour
{
    
    public GameObject open_prompt;
    private Transform lid;
    GameObject[] weapons;
    bool opened = false;
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

    void OnTriggerStay(Collider other)
    {
        open_prompt.SetActive(true);
        if (Input.GetKey(KeyCode.E) && !opened)
        {
            opened = true;
            lid.DORotate(new Vector3(-45, -180, 0), 1f);
            open_prompt.SetActive(false);
            StartCoroutine(CycleWeapons());
            
        }
        
    }

    IEnumerator CycleWeapons()
    {
        GameObject currWeapon = weapons[0];
            for(int i = 0; i < 10; i++)
            {
                currWeapon.SetActive(false);
                int r = Random.Range(0,weapons.Length);
                currWeapon = weapons[r];
                currWeapon.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
        lid.DORotate(new Vector3(0, -180, 0), 1f);
        opened = false;
        
    }


    void OnTriggerExit(Collider other)
    {
        open_prompt.SetActive(false);
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class Gun : MonoBehaviour
{
    public int damage = 1;
    public int AmmoInGun = 30;
    public int storedAmmo = 90;
    public int magSize = 30;
    public int loadNumBullets;
    public Animator recoil;
    public Camera fpsCam;
    public TMP_Text AmmoGUI;

    void OnEnable()
        {
            
            AmmoGUI.gameObject.SetActive(true);
        }

        void OnDisable()
        {
            AmmoGUI.gameObject.SetActive(false);
        }

    void Update()
    {
        AmmoGUI.text = $"{AmmoInGun}/{storedAmmo}";

        if (Input.GetButtonDown("Fire1") && AmmoInGun > 0)
        {
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.R) && AmmoInGun < magSize && storedAmmo > 0)
        {
            Reload();
        }
    }

    public void Shoot()
    {  
        recoil.Play("Recoil");
        AmmoInGun-=1;
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * 100f, Color.red, 1f);
        RaycastHit hit;

        int layerMask = 1 << LayerMask.NameToLayer("enemy");
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
        }
    }
    public void Reload()
    {
        recoil.Play("Reload");
        if (storedAmmo>=magSize)
        {
            loadNumBullets = magSize-AmmoInGun;
            AmmoInGun+= loadNumBullets;
            storedAmmo-= loadNumBullets;
            
        }
        else if (storedAmmo < magSize)
        {
            loadNumBullets = storedAmmo-AmmoInGun;
            AmmoInGun+= loadNumBullets;
            storedAmmo-= loadNumBullets;
        }
        
    }
}
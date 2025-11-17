using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public int damage = 100;
    public Animator recoil;
    public Camera fpsCam;
    

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    public void Shoot()
    {
        recoil.Play("Recoil");
        Vector3 rayOrigin = fpsCam.transform.position + fpsCam.transform.forward * 0.1f;
        Debug.DrawRay(rayOrigin, fpsCam.transform.forward * 100f, Color.blue, 2f);  // Fixed line

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public int damage = 100;
    public Animator recoil;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject muzzleFlashEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    public void Shoot()
    {
        muzzleFlash.Play();
        recoil.Play("Recoil");

        Vector3 rayOrigin = fpsCam.transform.position + fpsCam.transform.forward * 0.1f;
        Debug.DrawRay(rayOrigin, fpsCam.transform.forward * 100f, Color.blue, 2f);  // Fixed line

        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hitInfo))
        {
            GameObject Effect = Instantiate(muzzleFlashEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(Effect, 2f);
        }
    }
}
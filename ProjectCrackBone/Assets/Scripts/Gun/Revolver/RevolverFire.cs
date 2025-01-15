using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverFire : RevolverBasics,IFire
{
    [SerializeField] Transform firePoint;
    Animator anim;
    [SerializeField] Image crosshair;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Shoot(KeyCode fireKey, Transform firePoint)
    {
        if (Input.GetKeyDown(fireKey) && RevolverStats["Ammo"] > 0)
        {
            Debug.DrawRay(firePoint.position, transform.TransformDirection(Vector3.forward) * RevolverStats["Range"], Color.red);
            int layerMask = LayerMask.GetMask("Enemy","Default");
            if (Physics.Raycast(firePoint.position, transform.TransformDirection(Vector3.forward), out RaycastHit Hit, RevolverStats["Range"], layerMask))
            {
                if (Hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    StartCoroutine(PublicMethods.ColorChange(crosshair, Color.white, Color.red));
                    Hit.collider.gameObject.GetComponent<EnemyHealth>().GetHit();
                }
                
            }
            RevolverStats["Ammo"]--;
            AmmoCheck();
            if (RevolverStats["Ammo"] > 0)
            {
                anim.SetTrigger("Shoot");
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && RevolverStats["Ammo"] < 6)
        {
            StartCoroutine(Reload());
        }
    }

    void Update()
    {
        Shoot(KeyCode.Mouse0, firePoint);
    }

    void AmmoCheck()
    {
        if (RevolverStats["Ammo"] == 0)
        {
            StartCoroutine(Reload());
        }
        else if (RevolverStats["Ammo"] < 0)
        {
            return;
        }
    }

    IEnumerator Reload()
    {
        anim.SetTrigger("Reload");
        Debug.Log("Mermi Deðiþtiriliyor...");
        yield return new WaitForSeconds(2);
        RevolverStats["Ammo"] = RevolverStats["MagazineSize"];
        Debug.Log("Mermi Deðiþtirildi");
    }
}

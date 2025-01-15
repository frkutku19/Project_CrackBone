using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverFire : RevolverBasics,IFire
{
    [SerializeField] Transform firePoint;
    [SerializeField] KeyCode fireKey;
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
                    Debug.Log("Düþmana Vurdun");
                    StartCoroutine(PublicMethods.ColorChange(crosshair, Color.white, Color.red));
                }
                else if (Hit.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
                {
                    Debug.Log("Ateþ Edildi");
                }
                
            }
            RevolverStats["Ammo"]--;

            Debug.Log("Kalan Mermi: " + RevolverStats["Ammo"]);
            AmmoCheck();
            if (RevolverStats["Ammo"] > 0)
            {
                anim.SetTrigger("Shoot");
            }
        }
    }

    void Update()
    {
        Shoot(fireKey, firePoint);
        Debug.DrawRay(firePoint.position, transform.TransformDirection(Vector3.forward) * RevolverStats["Range"], Color.red);
    }

    void AmmoCheck()
    {
        if (RevolverStats["Ammo"] == 0)
        {
            Debug.Log("Mermin Bitti Amk");
            anim.SetTrigger("Reload");
            StartCoroutine(Reload());
        }
        else if (RevolverStats["Ammo"] < 0)
        {
            return;
        }
    }

    IEnumerator Reload()
    {
        Debug.Log("Mermi Deðiþtiriliyor...");
        yield return new WaitForSeconds(RevolverStats["ReloadTime"]);
        RevolverStats["Ammo"] = RevolverStats["MagazineSize"];
        Debug.Log("Mermi Deðiþtirildi");
    }
}

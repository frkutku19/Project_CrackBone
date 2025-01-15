using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverMelee : RevolverBasics,IFire
{

    Animator anim;
    [SerializeField] Transform firePoint;
    [SerializeField] Image crosshair;
    float cooldown = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Shoot(KeyCode fireKey, Transform firePoint)
    {
        
        cooldown += Time.deltaTime;
        Debug.Log(cooldown);
        if (cooldown > RevolverStats["MeleeCoolDown"])
        {
            cooldown = RevolverStats["MeleeCoolDown"];
        }

        if (Input.GetKeyDown(fireKey) && cooldown >= RevolverStats["MeleeCoolDown"])
        {
            Debug.DrawRay(firePoint.position, transform.TransformDirection(Vector3.forward) * RevolverStats["MeleeRange"], Color.blue);
            int layerMask = LayerMask.GetMask("Enemy", "Default");
            if (Physics.Raycast(firePoint.position, transform.TransformDirection(Vector3.forward), out RaycastHit Hit, RevolverStats["MeleeRange"], layerMask))
            {
                if (Hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    StartCoroutine(PublicMethods.ColorChange(crosshair, Color.white, Color.red));
                    Hit.collider.gameObject.GetComponent<EnemyHealth>().GetMeleeHit();
                }

            }
            anim.SetTrigger("Melee");
            cooldown = 0;
        }
    }

    void Update()
    {
        Shoot(KeyCode.V, firePoint);
        Debug.DrawRay(firePoint.position, transform.TransformDirection(Vector3.forward) * RevolverStats["MeleeRange"], Color.blue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    Slider healthSlider;

    EnemyStats stats;
    void Start()
    {
        healthSlider = GetComponentInChildren<Slider>();

        stats = GetComponent<EnemyStats>();
        healthSlider.value = stats.enemyStats["Health"];
    }
    public void GetHit()
    {
        stats.enemyStats["Health"] -= RevolverBasics.RevolverStats["Damage"];
        SliderUpdate();
        IsDead();
    }
    public void GetMeleeHit()
    {
        stats.enemyStats["Health"] -= RevolverBasics.RevolverStats["MeleeDamage"];
        SliderUpdate();
        IsDead();
    }
    void SliderUpdate()
    {
        healthSlider.value = stats.enemyStats["Health"];
    }
    void IsDead()
    {
        if (stats.enemyStats["Health"] <= 0)
        {
            stats.enemyStats["Health"] = 0;
            Destroy(this.gameObject);
        }
    }
}

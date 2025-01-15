using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBasics : MonoBehaviour
{
    public Dictionary<string,float> RevolverStats = new Dictionary<string,float>();

    private void Start()
    {
        RevolverStats.Add("Ammo", 6);
        RevolverStats.Add("Damage", 60);
        RevolverStats.Add("FireCooldown", 2);
        RevolverStats.Add("Range", 8);
        RevolverStats.Add("ReloadTime", 2);
        RevolverStats.Add("MagazineSize", 6);
    }
}

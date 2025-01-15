using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBasics : MonoBehaviour
{
    public static Dictionary<string,float> RevolverStats = new Dictionary<string,float>();

    private void Awake()
    {

        RevolverStats.TryAdd("Ammo", 6);
        RevolverStats.TryAdd("Damage", 60);
        RevolverStats.TryAdd("FireCooldown", 2);
        RevolverStats.TryAdd("Range", 8);
        RevolverStats.TryAdd("MagazineSize", 6);
    }
}

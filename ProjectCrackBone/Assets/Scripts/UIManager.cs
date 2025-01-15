using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text enemyRemaining;
    public Text ammoText;
    void Start()
    {
        PublicMethods.MakeGameObjectList("Enemy");
    }

    void Update()
    {
        enemyRemaining.text = "Enemy Left: " + PublicMethods.MakeGameObjectList("Enemy").Length.ToString();
        ammoText.text = RevolverBasics.RevolverStats["Ammo"].ToString() + "/" + RevolverBasics.RevolverStats["MagazineSize"].ToString();
    }
}

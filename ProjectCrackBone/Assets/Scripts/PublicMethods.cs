using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PublicMethods : MonoBehaviour
{
    static public IEnumerator ColorChange(Image image, Color firstColor, Color newColor)
    {
       image.color = newColor;
       yield return new WaitForSeconds(.1f);
       image.color = firstColor;
    }
    static public IEnumerator ColorChange(Material material, Color firstColor, Color newColor)
    {
        material.color = newColor;
        yield return new WaitForSeconds(.1f);
        material.color = firstColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLightCube : MonoBehaviour
{
    private void OnMouseDown()
    {
        Light myLight = GetComponentInChildren<Light>();
        myLight.enabled = true;
    }
}

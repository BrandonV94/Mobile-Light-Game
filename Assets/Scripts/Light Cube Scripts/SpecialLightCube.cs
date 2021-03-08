using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLightCube : MonoBehaviour
{
    Light myLight;

    private void Awake()
    {
        myLight = GetComponentInChildren<Light>();
    }

    private void OnMouseDown()
    {
        myLight.enabled = true;
        Invoke(nameof(TapLightOff), 0.7f);
    }

    void TapLightOff()
    {
        myLight.enabled = false;
    }
}

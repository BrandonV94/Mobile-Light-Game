using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfActive : MonoBehaviour
{
    LightCubeII lightCubeII = null;
    void Awake()
    {
        lightCubeII = GetComponentInParent<LightCubeII>();
    }

    void Update()
    {
        CheckCubeLight();
    }

    void CheckCubeLight()
    {
        if (this.gameObject.activeSelf == true)
        {
            lightCubeII.isLightCubeOn = true;
        }
        else
        {
            lightCubeII.isLightCubeOn = false;
        }
    }
}

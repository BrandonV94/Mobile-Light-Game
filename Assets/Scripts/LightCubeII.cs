using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCubeII : MonoBehaviour
{
    Light lightSource = null;
    [SerializeField] public bool isLightCubeOn = true;
    [SerializeField] int timeClicked = 0;

    void Awake()
    {
        lightSource = GetComponentInChildren<Light>();
    }

    void Update()
    {
        CheckCubeLight();
    }

    private void OnMouseDown()
    {
        if (isLightCubeOn)
        {
            TurnCubeLightOff();
            timeClicked++;
        }
    }

    public void TurnCubeLightOff()
    {
        lightSource.gameObject.SetActive(false);
        isLightCubeOn = false;
    }

    public void TurnCubeLightOn()
    {
        lightSource.gameObject.SetActive(true);
        isLightCubeOn = true;
    }

    void CheckCubeLight()
    {
        if (lightSource.gameObject.activeSelf == true)
        {
            isLightCubeOn = true;
        }
        else
        {
            isLightCubeOn = false;
        }
    }
}

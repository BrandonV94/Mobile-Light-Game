using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCubeII : MonoBehaviour
{
    [SerializeField] Light lightSource = null;
    [SerializeField] bool isLightCubeOn = true;

    void Start()
    {
    
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (isLightCubeOn)
        {
           //Debug.Log("Turning off " + this.name + ".");
            TurnCubeLightOff();
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

    void CheckCubeLight() {
        if (this.gameObject.activeSelf)
        {
            isLightCubeOn = true;
        }
        else
        {
            isLightCubeOn = false;
        }
    }

}

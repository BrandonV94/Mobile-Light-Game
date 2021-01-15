using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCube : MonoBehaviour
{
    Material emissionSource = null;
    Light lightSource = null;

    void Start()
    {
        emissionSource = GetComponent<Renderer>().material;
        lightSource = GetComponentInChildren<Light>();
        emissionSource.EnableKeyword("_EMISSION");
    }


    void Update()
    {
        Debug.Log(this.name + " is on: " + emissionSource.IsKeywordEnabled("_Emissions"));
    }

    private void OnMouseDown()
    {
        Debug.Log("Turning off " + this.name + ".");
        turnOffCubeLight();
        Debug.Log(this.name + " is on: " + emissionSource.IsKeywordEnabled("_Emissions"));
    }

    private void turnOffCubeLight()
    {
        lightSource.gameObject.SetActive(false);
        emissionSource.DisableKeyword("_EMISSION");
    }
}

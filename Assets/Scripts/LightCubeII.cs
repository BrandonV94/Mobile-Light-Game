using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCubeII : MonoBehaviour
{
    [SerializeField] Light lightSource = null;

    void Start()
    {
    
    }


    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Turning off " + this.name + ".");
        turnOffCubeLight();
    }

    private void turnOffCubeLight()
    {
        lightSource.gameObject.SetActive(false);
    }
}

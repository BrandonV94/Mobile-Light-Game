using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    [SerializeField] public Light easyCubeLight = null;
    [SerializeField] Light mediumCubeLight = null;
    [SerializeField] Light hardCubeLight = null;

    bool easyCubeOn;
    bool mediumCubeOn;
    bool hardCubeOn;

    [SerializeField] public Light currentDiffLight = null;
    [SerializeField] public Light newDiffLight = null;

    void Start()
    {
        GetDifficultyCubeLights();
        currentDiffLight = mediumCubeLight;
        newDiffLight = mediumCubeLight;
    }

    void Update()
    {
        currentDiffLight.enabled = true;
        if(currentDiffLight != newDiffLight)
        {
            ChangeDifficulty();
        }
    }

    void ChangeDifficulty()
    {
        currentDiffLight.enabled = false;
        currentDiffLight = newDiffLight;
        currentDiffLight.enabled = true;
    }

    void GetDifficultyCubeLights()
    {
        easyCubeLight = GameObject.Find("Main Cubes/Special Light Cube II (Easy)/Light Source II").GetComponent<Light>();
        mediumCubeLight = GameObject.Find("Main Cubes/Special Light Cube II (Medium)/Light Source II").GetComponent<Light>();
        hardCubeLight = GameObject.Find("Main Cubes/Special Light Cube II (Hard)/Light Source II").GetComponent<Light>();
    }

    public void SetEasyDifficulty()
    {
        newDiffLight = easyCubeLight;
    }

    public void SetMediumDifficulty()
    {
        newDiffLight = mediumCubeLight;
    }

    public void SetHardDifficulty()
    {
        newDiffLight = hardCubeLight;
    }
}


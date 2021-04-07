using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    SettingsController settingsController = null;
    PlayerPrefsController playerPrefsController = null;

    [Header("Difficulty Cube Lights")]
    [SerializeField] public Light easyCubeLight = null;
    [SerializeField] Light mediumCubeLight = null;
    [SerializeField] Light hardCubeLight = null;

    bool easyCubeOn;
    bool mediumCubeOn;
    bool hardCubeOn;

    [Header("Cube Light States")]
    [SerializeField] public Light currentDiffLight = null;
    [SerializeField] public Light newDiffLight = null;

    private void Awake()
    {
        settingsController = FindObjectOfType<SettingsController>();
        playerPrefsController = FindObjectOfType<PlayerPrefsController>();
    }

    void Start()
    {
        GetDifficultyCubeLights();
        currentDiffLight = mediumCubeLight;
        newDiffLight = mediumCubeLight;
    }

    void Update()
    {
        SetCurrentDifficultyCube();
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

    void SetCurrentDifficultyCube()
    {
        if (PlayerPrefsController.GetDifficultySetting() == settingsController.easySpeed) { SetEasyDifficulty(); }
        if (PlayerPrefsController.GetDifficultySetting() == settingsController.mediumSpeed) { SetMediumDifficulty(); }
        if (PlayerPrefsController.GetDifficultySetting() == settingsController.hardSpeed) { SetHardDifficulty(); }
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


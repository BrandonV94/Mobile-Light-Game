using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    // Necessary class variables
    PlayerPrefsController playerPrefsController = null;
    RandomCubeGenerator randomCubeGenerator = null;
    DifficultyController difficultyController;

    // Volume Settings
    [Header("Volume Settings")]
    [SerializeField] public Slider volumeSlider = null;
    [SerializeField] const float defaultVolume = .5f;

    // Speed Settings
    [Header("Difficulty Speed Settings")]
    [SerializeField] public float easySpeed = .8f;
    [SerializeField] public float mediumSpeed = .7f;
    [SerializeField] public float hardSpeed = .6f;



    void Start()
    {
        playerPrefsController = FindObjectOfType<PlayerPrefsController>();
        randomCubeGenerator = FindObjectOfType<RandomCubeGenerator>();
        difficultyController = FindObjectOfType<DifficultyController>();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    void Update()
    {
        var musicController = FindObjectOfType<MusicController>();
        if(musicController)
        {
            musicController.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogError("No music controller available");
        }
    }

    // Setting's menu methods
    public void SaveAndMainMenu()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<SceneController>().DelayedLoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        PlayerPrefsController.SetDifficultySetting(mediumSpeed);
    }

    // Difficulty Settings
    public void SetEasyMode()
    {
        Debug.Log("The timer has been set to " + easySpeed);
        PlayerPrefsController.SetDifficultySetting(easySpeed);
    }

    public void SetMediumMode()
    {
        Debug.Log("The timer has been set to " + mediumSpeed);
        PlayerPrefsController.SetDifficultySetting(mediumSpeed);
    }

    public void SetHardMode()
    {
        Debug.Log("The timer has been set to " + hardSpeed);
        PlayerPrefsController.SetDifficultySetting(hardSpeed);
    }
}

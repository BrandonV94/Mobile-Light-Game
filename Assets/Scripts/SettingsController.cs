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
    [SerializeField] float easySpeed = .8f;
    [SerializeField] float mediumSpeed = .7f;
    [SerializeField] float hardSpeed = .6f;



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

    // Setting menu methods
    public void SaveAndMainMenu()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<SceneController>().DelayedLoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }

    // Difficulty Settings
    public void SetEasyMode()
    {
        Debug.Log("The timer has been set to .8");
        PlayerPrefsController.SetDifficultySetting(easySpeed);
    }

    public void SetMediumMode()
    {
        Debug.Log("The timer has been set to .7");
        PlayerPrefsController.SetDifficultySetting(mediumSpeed);
    }

    public void SetHardMode()
    {
        Debug.Log("The timer has been set to .6");
        PlayerPrefsController.SetDifficultySetting(hardSpeed);
    }
}

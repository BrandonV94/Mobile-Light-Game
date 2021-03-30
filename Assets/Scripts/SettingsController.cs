using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    PlayerPrefsController playerPrefsController = null;
    RandomCubeGenerator randomCubeGenerator = null;
    [SerializeField] public Slider volumeSlider = null;
    [SerializeField] const float defaultVolume = .5f;

    void Start()
    {
        playerPrefsController = FindObjectOfType<PlayerPrefsController>();
        randomCubeGenerator = FindObjectOfType<RandomCubeGenerator>();
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

    //Setting menu methods
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
        //randomCubeGenerator.SetCubeGeneratorTimer(.8f);
        Debug.Log("The timer has been set to .8");
        PlayerPrefsController.SetDifficultySetting(.8f);
    }

    public void SetMediumMode()
    {
        //randomCubeGenerator.SetCubeGeneratorTimer(.7f);
        Debug.Log("The timer has been set to .7");
        PlayerPrefsController.SetDifficultySetting(.7f);
    }

    public void SetHardMode()
    {
        //randomCubeGenerator.SetCubeGeneratorTimer(.6f);
        Debug.Log("The timer has been set to .6");
        PlayerPrefsController.SetDifficultySetting(.6f);
    }
}

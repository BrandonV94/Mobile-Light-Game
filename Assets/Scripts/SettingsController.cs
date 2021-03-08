using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

    [SerializeField] public Slider volumeSlider = null;
    [SerializeField] float defaultVolume = .4f;

    void Start()
    {
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

    public void SaveAndPlayGame()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<SceneController>().DelayedStartGame();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}

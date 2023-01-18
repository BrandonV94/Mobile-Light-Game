using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DEFAULT_MASTER_VOLUME_KEY = "default volume";
    const string DIFFICULTY_SETTING_KEY = "difficulty_setting";


    [SerializeField] const float MIN_VOLUME = 0f;
    [SerializeField] const float MAX_VOLUME = 1f;

    // Volume Set and Get 
    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Music volume is out of range.");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    // Difficulty Set and Get
    public static void SetDifficultySetting(float setting)
    {
        PlayerPrefs.SetFloat(DIFFICULTY_SETTING_KEY, setting);
    }

    public static float GetDifficultySetting()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_SETTING_KEY);
    }
}

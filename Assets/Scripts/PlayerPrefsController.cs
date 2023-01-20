using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    [Header("PlayerPrefs Keys")]
    [SerializeField] const string MASTER_VOLUME_KEY = "master volume";
    [SerializeField] const string DIFFICULTY_SETTING_KEY = "difficulty_setting";

    [Header("Constants")]
    [SerializeField] const float MIN_VOLUME = 0f;
    [SerializeField] const float MAX_VOLUME = 1f;
    [SerializeField] const float DEFAULT_DIFFICULTY = .7f;
    [SerializeField] const float DEFAULT_VOLUME = .7f;

    // Volume Set and Get 
    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            PlayerPrefs.SetFloat(DIFFICULTY_SETTING_KEY, DEFAULT_VOLUME);
            Debug.LogError("Music volume is out of range.");
        }
        PlayerPrefs.Save();
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    // Difficulty Set and Get
    public static void SetDifficultySetting(float setting)
    {
        if(setting > 0)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_SETTING_KEY, setting);
        }
        else
        {
            PlayerPrefs.SetFloat(DIFFICULTY_SETTING_KEY, DEFAULT_DIFFICULTY);
        }
        PlayerPrefs.Save();
    }

    public static float GetDifficultySetting()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_SETTING_KEY);
    }
}

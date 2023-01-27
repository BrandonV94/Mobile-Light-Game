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
    [SerializeField] const float DEFAULT_VOLUME = .5f;

    private void Start()
    {
        if(GetMasterVolume() == 0f && GetDifficultySetting() == 0f)
        {
            SetMasterVolume(DEFAULT_VOLUME);
            SetDifficultySetting(DEFAULT_DIFFICULTY);
        }
    }

    // Volume Set and Get 
    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            PlayerPrefs.Save();
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
        if(setting > 0f && setting < 1f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_SETTING_KEY, setting);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Difficulty setting out of range.");
        }
    }

    public static float GetDifficultySetting()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_SETTING_KEY);
    }
}

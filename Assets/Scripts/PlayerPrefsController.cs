using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DEFAULT_MASTER_VOLUME = "default volume";


    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    private void Awake()
    {
        int playerPrefsControllerCount = FindObjectsOfType<PlayerPrefsController>().Length;
        if (playerPrefsControllerCount > 1)
        {
            // Line used to prevent any bugs from ocuring before object is destroyed.
            gameObject.SetActive(false);
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }

    }

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
}

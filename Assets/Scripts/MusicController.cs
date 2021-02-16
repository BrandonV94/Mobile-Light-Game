using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private void Awake()
    {
        int musicControllerCount = FindObjectsOfType<MusicController>().Length;
        if (musicControllerCount > 1)
        {
            // Line used to prevent any bugs from ocuring before object is destroyed.
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

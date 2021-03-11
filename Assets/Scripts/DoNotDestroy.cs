using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        int doNotDestroyCount = FindObjectsOfType<DoNotDestroy>().Length;
        if (doNotDestroyCount > 1)
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
}

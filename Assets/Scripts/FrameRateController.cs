using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    [SerializeField] int target = 60;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    void Update()
    {
        if(target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }
    }
}

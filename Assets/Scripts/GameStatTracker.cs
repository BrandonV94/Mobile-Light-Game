using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatTracker : MonoBehaviour
{
    public Text rndCubeTimer;
    public Text decVal;
    public Text chngSpd;
    public Text timePssd;

    public GameObject rndCubeGen;
    public RandomCubeGenerator rndCubeScript;

    private void Awake()
    {
        rndCubeScript = rndCubeGen.GetComponent<RandomCubeGenerator>();
    }

    void Update()
    {
        rndCubeTimer.text = "Random Cube Timer: " + rndCubeScript.randomCubeTimer;
        decVal.text = "Decremental Value: " + rndCubeScript.decrementalValue;
        chngSpd.text = "Change Speed: " + rndCubeScript.changeSpeedTime;
        timePssd.text = "Time Passed: " + rndCubeScript.timePassed;
    }
}

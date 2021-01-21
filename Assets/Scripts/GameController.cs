using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] cubeLightArray = null;
    [SerializeField] float turnLightsOnOffSlowlyDelay = 1f;
    [SerializeField] float randomDelayTimer = 1f;
    [SerializeField] GameTimer gameTimer = null;

    private void Awake()
    {
        gameTimer = GetComponent<GameTimer>();
    }

    void Start()
    {
        CreateCubeLightArray();
        StartCoroutine("TurnOffCubeLightsSlowly");
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            Debug.Log("Activating Countdown Clock");
            gameTimer.enabled = true;
        }

        if(gameTimer.isActiveAndEnabled == true)
        {
            TurnRandomCubeLightOn();
        }
    }

    void CreateCubeLightArray()
    {
        //Debug.Log("Locating all cube lights.");
        cubeLightArray = GameObject.FindGameObjectsWithTag("Light Source");
    }

    private void TurnRandomCubeLightOn()
    {
        int randNum = Random.Range(0, cubeLightArray.Length);
        var randomCubeLight = cubeLightArray[randNum];
        Debug.Log(randomCubeLight.transform.parent.name + " is being turned on randomly.");
        randomCubeLight.SetActive(true);
    }

    IEnumerator TurnOffCubeLightsSlowly()
    {
        foreach(GameObject cube in cubeLightArray)
        {
            cube.SetActive(false);
            yield return new WaitForSeconds(turnLightsOnOffSlowlyDelay);
        }
    }

    IEnumerator TurnOnCubeLightsSlowly()
    {
        System.Array.Reverse(cubeLightArray);
        foreach (GameObject cube in cubeLightArray)
        {
            cube.SetActive(true);
            yield return new WaitForSeconds(turnLightsOnOffSlowlyDelay);
        }
    }

    IEnumerator TurnLightsOnRandomly()
    {
        TurnRandomCubeLightOn();
        yield return new WaitForSeconds(randomDelayTimer);
    }
}

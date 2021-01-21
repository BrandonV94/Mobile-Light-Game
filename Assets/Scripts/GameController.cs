using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameTimer gameTimer = null;
    [SerializeField] RandomCubeGenerator rndCubeGenerator = null;
    [SerializeField] GameObject[] cubeLightArray = null;
    [SerializeField] float turnLightsOnOffSlowlyDelay = 1f;

    private void Awake()
    {
        gameTimer = GetComponent<GameTimer>();
        rndCubeGenerator = GetComponent<RandomCubeGenerator>();
        TurnOffGameComponentsOnstart();
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
            rndCubeGenerator.enabled = true;
        }
    }

    void CreateCubeLightArray()
    {
        //Debug.Log("Locating all cube lights.");
        cubeLightArray = GameObject.FindGameObjectsWithTag("Light Source");
    }

    public void TurnRandomCubeLightOn()
    {
        if(cubeLightArray.Length > 0)
        {
            int randNum = Random.Range(0, cubeLightArray.Length);
            Debug.Log("Random number generated: " + randNum);
            Debug.Log("Random cube being selected is: " + cubeLightArray[randNum]);
            var randomCubeLight = cubeLightArray[randNum];
            randomCubeLight.SetActive(true);
        }
    }

    void TurnOffGameComponentsOnstart()
    {
        gameTimer.enabled = false;
        rndCubeGenerator.enabled = false;
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
}

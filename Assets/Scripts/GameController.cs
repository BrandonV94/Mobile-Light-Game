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
            gameTimer.enabled = true;
            rndCubeGenerator.enabled = true;
        }
    }

    void CreateCubeLightArray()
    {
        cubeLightArray = GameObject.FindGameObjectsWithTag("Light Source");
    }

    public void TurnRandomCubeLightOn()
    {
        if(cubeLightArray.Length > 0)
        {
            int randNum = Random.Range(0, cubeLightArray.Length);
            var randomCubeLight = cubeLightArray[randNum];
            if(randomCubeLight.activeInHierarchy == false)
            {
                //Debug.Log("Turning on " + randomCubeLight.name + " " + randNum);
                randomCubeLight.SetActive(true);
            }
            else
            {
                //Debug.Log(randomCubeLight.name + " " + randNum + " is already on.");
            }
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

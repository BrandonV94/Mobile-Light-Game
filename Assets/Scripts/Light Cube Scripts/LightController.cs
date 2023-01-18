using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject[] cubeLightsInScene = null;
    [SerializeField] GameObject[] bgCubeLightsInScene = null;
    [SerializeField] GameObject[] mainMenuCubeLights = null;
    [SerializeField] int sceneIndex = 0;
    [SerializeField] float turnLightsOnOffSlowlyDelay = 1f; // .2 works fine

    private void Awake()
    {
        FindAllCubesInScene();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        StartCoroutine(TurnCubeLightsOffSlowly());   
    }

    private void FindAllCubesInScene()
    {
        GetGameCubes();
        GetMenuCubes();
        GetBackgroundCubes();
    }

    void GetGameCubes()
    {
        cubeLightsInScene = GameObject.FindGameObjectsWithTag("Light Source");
    }

    void GetMenuCubes()
    {
        mainMenuCubeLights = GameObject.FindGameObjectsWithTag("Main Cube Lights");
    }

    void GetBackgroundCubes()
    {
        bgCubeLightsInScene = GameObject.FindGameObjectsWithTag("BG Cube Lights");
    }
    
    // Begining of the game sequences.
    IEnumerator TurnCubeLightsOffSlowly()
    {
        foreach (GameObject cube in cubeLightsInScene)
        {
            cube.SetActive(false);
            yield return new WaitForSeconds(turnLightsOnOffSlowlyDelay);
        }
        Destroy(gameObject);
    }

    IEnumerator TurnCubeLightsOnSlowly()
    {
        System.Array.Reverse(cubeLightsInScene);
        foreach (GameObject cube in cubeLightsInScene)
        {
            cube.SetActive(true);
            yield return new WaitForSeconds(turnLightsOnOffSlowlyDelay);
        }
    }
}
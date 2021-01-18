using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] cubeArray = null;
    [SerializeField] float timerDelay = 1f;

    void Start()
    {
        CheckCubeArray();
    }


    void Update()
    {
        
    }

    void CheckCubeArray()
    {
        Debug.Log("Locating all cubes.");
        cubeArray = GameObject.FindGameObjectsWithTag("Light Cube");
        foreach (GameObject cube in cubeArray)
        {
            Debug.Log(cube.name + " was added to the cubeArray.");
        }
    }

    IEnumerator TurnOffCubeLightsSlowly()
    {
        //turn cube light.
        yeild return new WaitForSeconds(timerDelay);
    }
}

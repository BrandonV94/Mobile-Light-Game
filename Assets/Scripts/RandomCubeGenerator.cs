﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeGenerator : MonoBehaviour
{
    GameTimer gameTimer = null;
    GameController gameController = null;
    [SerializeField] public GameObject[] cubeLightArray = null;
    [SerializeField] float randomDelayTimer = 1f;

    private void Awake()
    {
        CreateCubeLightArray();
        gameController = GetComponent<GameController>();
        gameTimer = GetComponent<GameTimer>();
    }

    void Start()
    {
        StartCoroutine(TurnLightsOnRandomly());
    }

    IEnumerator TurnLightsOnRandomly()
    {
        while(gameTimer.countdownTimer > 0)
        {
            TurnRandomCubeLightOn();
            yield return new WaitForSeconds(randomDelayTimer);
        }
    }

    void CreateCubeLightArray()
    {
        cubeLightArray = GameObject.FindGameObjectsWithTag("Light Source");
    }

    public void TurnRandomCubeLightOn()
    {
        if (cubeLightArray.Length > 0)
        {
            int randNum = Random.Range(0, cubeLightArray.Length);
            var randomCubeLight = cubeLightArray[randNum];
            if (randomCubeLight.activeInHierarchy == false)
            {
                randomCubeLight.SetActive(true);
            }
        }
    }
}
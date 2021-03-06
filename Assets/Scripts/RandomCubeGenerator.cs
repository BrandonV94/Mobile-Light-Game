﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeGenerator : MonoBehaviour
{
    GameTimer gameTimer = null;
    GameController gameController = null;

    [Header("Random Cube Generator Mechanics")]
    [SerializeField] public GameObject[] gameCubeLightArray = null;
    [Tooltip("Value for how long between random cube selection.")]
    [SerializeField] float randomCubeTimer = 1f;
    [SerializeField] float decrementalValue = .2f;
    [SerializeField] float changeSpeedTime = 10f;
    [SerializeField] float timePassed = 0;


    private void Awake()
    {
        CreateCubeLightArray();
        gameTimer = GetComponent<GameTimer>();
        gameController = FindObjectOfType<GameController>();
    }

    void Start()
    {
        SetCubeGeneratorTimer();
        StartCoroutine(TurnLightsOnRandomly());
    }

    private void Update()
    {
        CheckIfGameOver();
        CalculateTimePassed();
        IncreaseGeneratorSpeed();
    }

    IEnumerator TurnLightsOnRandomly()
    {
        while (gameTimer.timeRemaining > 0)
        {
            TurnRandomCubeLightOn();
            yield return new WaitForSeconds(randomCubeTimer);
        }
    }

    void CreateCubeLightArray()
    {
        gameCubeLightArray = GameObject.FindGameObjectsWithTag("Light Source");
    }

    public void TurnRandomCubeLightOn()
    {
        if (gameCubeLightArray.Length > 0)
        {
            int randNum = Random.Range(0, gameCubeLightArray.Length);
            var randomCubeLight = gameCubeLightArray[randNum];
            if (randomCubeLight.activeInHierarchy == false)
            {
                randomCubeLight.SetActive(true);
            }
        }
    }

    void CalculateTimePassed()
    {
        timePassed += Time.deltaTime;
    }

    void IncreaseGeneratorSpeed()
    {
        if(timePassed > changeSpeedTime)
        {
            timePassed = 0f;
            randomCubeTimer -= decrementalValue;
        }
    }

    void CheckIfGameOver()
    {
        if (gameController.isGameOver == true)
        {
            Destroy(GetComponent<RandomCubeGenerator>());
        }
    }

    public void SetCubeGeneratorTimer()
    {
        randomCubeTimer = PlayerPrefsController.GetDifficultySetting();
    }
}

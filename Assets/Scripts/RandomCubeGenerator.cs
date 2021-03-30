using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeGenerator : MonoBehaviour
{
    GameTimer gameTimer = null;
    [SerializeField] public GameObject[] gameCubeLightArray = null;
    [SerializeField] float randomCubeTimer = 1f;
    [SerializeField] float timePassed = 0;
    [SerializeField] float decrementalValue = .2f;
    [SerializeField] float changeSpeedTime = 10f;

    private void Awake()
    {
        CreateCubeLightArray();
        gameTimer = GetComponent<GameTimer>();
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
                Debug.Log("Activating " + randomCubeLight.transform.parent.name);
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
        if (GameController.isGameOver == true)
        {
            Destroy(GetComponent<RandomCubeGenerator>());
        }
    }

    public void SetCubeGeneratorTimer()
    {
        //return randomCubeTimer = value;
        randomCubeTimer = PlayerPrefsController.GetDifficultySetting();
    }
}

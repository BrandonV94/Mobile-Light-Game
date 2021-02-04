using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    GameTimer gameTimer = null;
    RandomCubeGenerator rndCubeGenerator = null;
    ScoreBoard scoreBoard = null;
    [SerializeField] float turnLightsOnOffSlowlyDelay = 1f;
    [SerializeField] public int totalPoints = 0;

    private void Awake()
    {
        gameTimer = GetComponent<GameTimer>();
        rndCubeGenerator = GetComponent<RandomCubeGenerator>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        TurnOffGameComponentsOnstart();
    }

    void Start()
    {
        //StartCoroutine("TurnOffCubeLightsSlowly");
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            gameTimer.enabled = true;
            rndCubeGenerator.enabled = true;
        }
    }

    void TurnOffGameComponentsOnstart()
    {
        gameTimer.enabled = false;
        rndCubeGenerator.enabled = false;
    }

    // Begining of the game sequences.
    IEnumerator TurnOffCubeLightsSlowly()
    {
        foreach(GameObject cube in rndCubeGenerator.cubeLightArray)
        {
            cube.SetActive(false);
            yield return new WaitForSeconds(turnLightsOnOffSlowlyDelay);
        }
    }

    IEnumerator TurnOnCubeLightsSlowly()
    {
        System.Array.Reverse(rndCubeGenerator.cubeLightArray);
        foreach (GameObject cube in rndCubeGenerator.cubeLightArray)
        {
            cube.SetActive(true);
            yield return new WaitForSeconds(turnLightsOnOffSlowlyDelay);
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}

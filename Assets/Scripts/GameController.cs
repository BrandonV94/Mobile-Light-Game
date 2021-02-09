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
    [SerializeField] Canvas gameCanvas = null;
    [SerializeField] Canvas gameOverCanvas = null;
    public bool isGameOver = false;
    [SerializeField] public int totalPoints = 0;

    private void Awake()
    {
        gameTimer = GetComponent<GameTimer>();
        rndCubeGenerator = GetComponent<RandomCubeGenerator>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void Start()
    {
        TurnOffGameComponentsOnstart();
        gameCanvas.enabled = true;
        gameOverCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            gameTimer.enabled = true;
            rndCubeGenerator.enabled = true;
        }

        if (isGameOver == true)
        {
            Debug.Log("Switching game canvases.");
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }
    }

    void TurnOffGameComponentsOnstart()
    {
        gameTimer.enabled = false;
        rndCubeGenerator.enabled = false;
    }
}

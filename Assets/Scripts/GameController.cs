using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Initialized Game Objects")]
    GameTimer gameTimer = null;
    RandomCubeGenerator rndCubeGenerator = null;
    [SerializeField] Canvas gameCanvas = null;
    [SerializeField] Canvas gameOverCanvas = null;

    [Header("Game States")]
    [SerializeField] public bool isGameOver = false;
    [SerializeField] public bool isGamePaused = false;

    [Header("Game Mechanics")]
    [SerializeField] public int gameCountdownTimer = 0;
    [SerializeField] float gameOverDelay = 5f;
    [SerializeField] public int totalPoints = 0;

    private void Awake()
    {
        gameTimer = GetComponent<GameTimer>();
        rndCubeGenerator = GetComponent<RandomCubeGenerator>();
    }

    void Start()
    {
        DisableGameComponents();
        EnableGameCanvas();
        StartCoroutine(BeginCountdown());
    }

    void Update()
    {
        if (isGameOver == true) { Invoke(nameof(EnableGameOverCanvas), gameOverDelay); }
    }

    IEnumerator BeginCountdown()
    {
        while(gameCountdownTimer > 0)
        {
            yield return new WaitForSeconds(1f);
            gameCountdownTimer--;
        }
        EnableGameComponents();
    }

    private void EnableGameComponents()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            gameTimer.enabled = true;
            rndCubeGenerator.enabled = true;
        }
    }

    void DisableGameComponents()
    {
        gameTimer.enabled = false;
        rndCubeGenerator.enabled = false;
    }

    public void EnableGameCanvas()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            gameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
    }

    public void EnableGameOverCanvas()
    {
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = true;
    }
}
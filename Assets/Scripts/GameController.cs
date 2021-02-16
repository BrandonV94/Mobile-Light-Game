using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameTimer gameTimer = null;
    RandomCubeGenerator rndCubeGenerator = null;
    [SerializeField] Canvas gameCanvas = null;
    [SerializeField] Canvas gameOverCanvas = null;
    public bool isGameOver = false;
    public bool isGamePaused = false;
    [SerializeField] public int gameCountdownTimer = 0;
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
        if (isGameOver == true)
        {
            EnableGameOverCanvas();
        }
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
        gameTimer.enabled = true;
        rndCubeGenerator.enabled = true;
    }

    public void EnableGameCanvas()
    {
        gameCanvas.enabled = true;
        gameOverCanvas.enabled = false;
    }

    public void EnableGameOverCanvas()
    {
        gameCanvas.enabled = false;
        gameOverCanvas.enabled = true;
    }

    void DisableGameComponents()
    {
        gameTimer.enabled = false;
        rndCubeGenerator.enabled = false;
    }
}

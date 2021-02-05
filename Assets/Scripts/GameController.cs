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
    [SerializeField] GameObject gameCanvas = null;
    [SerializeField] GameObject gameOverCanvas = null;
    public bool isGameOver = false;
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
        gameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
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
            gameCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
        }
    }

    void TurnOffGameComponentsOnstart()
    {
        gameTimer.enabled = false;
        rndCubeGenerator.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

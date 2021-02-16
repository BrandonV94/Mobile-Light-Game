using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    GameController gameController = null;
    [SerializeField] Text scoreText = null;
    [SerializeField] Text finalScoreText = null;
    [SerializeField] Text gameCountdownTimer = null;

    private void Awake()
    {
        GetScoreBoardReferences();
    }

    void Update()
    {
        DisplayCountDown();
        DisplayScore();
    }

    void DisplayScore()
    {
        int score = gameController.totalPoints;
        scoreText.text = "Total: " + score.ToString();
        finalScoreText.text = "Final Score: " + score.ToString();
    }

    void DisplayCountDown()
    {
        gameCountdownTimer.text = gameController.gameCountdownTimer.ToString();

        if(gameController.gameCountdownTimer == 0)
        {
            gameCountdownTimer.enabled = false;
        }
    }

    private void GetScoreBoardReferences()
    {
        gameController = FindObjectOfType<GameController>();
        scoreText = GameObject.Find("Default Game Canvases/Game Canvas/Score").GetComponent<Text>();
        finalScoreText = GameObject.Find("Default Game Canvases/Game Over Canvas/Final Score Text").GetComponent<Text>();
        gameCountdownTimer = GameObject.Find("Default Game Canvases/Game Canvas/Game Countdown Timer").GetComponent<Text>();
    }
}

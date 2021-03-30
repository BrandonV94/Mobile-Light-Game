using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] GameController gameController = null;
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] TextMeshProUGUI gameCountdownTimer = null;
    [SerializeField] TextMeshProUGUI finalScoreText = null;

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
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        scoreText =
            GameObject.Find("Default Game Canvases/Game Canvas/Score (TMP)").GetComponent<TextMeshProUGUI>();
        finalScoreText =
            GameObject.Find("Default Game Canvases/Game Over Canvas/Final Score Text (TMP)").GetComponent<TextMeshProUGUI>();
        gameCountdownTimer =
            GameObject.Find("Default Game Canvases/Game Canvas/Game Countdown Timer (TMP)").GetComponent<TextMeshProUGUI>();
    }
}

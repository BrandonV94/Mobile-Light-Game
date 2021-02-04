using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    GameController gameController = null;
    GameTimer gameTimer = null;
    [SerializeField] Text scoreText = null;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        gameTimer = FindObjectOfType<GameTimer>();
        scoreText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        DisplayScore();
    }

    void DisplayScore()
    {
        int score = gameController.totalPoints;
        scoreText.text = "Total: " + score.ToString();
    }
}

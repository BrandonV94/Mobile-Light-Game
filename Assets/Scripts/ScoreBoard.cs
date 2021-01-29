using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    GameController gameController = null;
    GameTimer gameTimer = null;
    [SerializeField] Text scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        gameTimer = FindObjectOfType<GameTimer>();
        scoreText.GetComponent<Text>();
    }

    // Update is called once per frame
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

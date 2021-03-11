using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    GameController gameController = null;
    [SerializeField] float transitionDelay = 1f;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Scene loading mehtods
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadSettings()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Settings");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CloseMessageWindow()
    {
        var thankYouMessage = GameObject.FindWithTag("Message");
        Destroy(thankYouMessage);
    }

    // Time controlling methods
    public void PauseGame()
    {
        Time.timeScale = 0;
        GameController.isGamePaused = true;
        gameController.EnableGameOverCanvas();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameController.isGamePaused = false;
        gameController.EnableGameCanvas();
    }

    // Delayed scene loading methods
    public void DelayedStartGame()
    {
        Invoke(nameof(StartGame), transitionDelay);
    }

    public void DelayedLoadSettings()
    {
        Invoke(nameof(LoadSettings), transitionDelay);
    }

    public void DelayedLoadMainMenu()
    {
        Invoke(nameof(LoadMainMenu), transitionDelay);
    }
}

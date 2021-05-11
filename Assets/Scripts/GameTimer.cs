using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{   // TODO Make game audio go faster as time progresses.
    GameController gameController = null;
    [SerializeField] Slider timerSlider = null;
    [SerializeField] float gameCountdownTimer = 60f;
    [SerializeField] public float timeRemaining = 0f;

    private void Awake()
    {
        timerSlider = FindObjectOfType<Slider>();
        gameController = FindObjectOfType<GameController>();
    }

    void Start()
    {
        timeRemaining = gameCountdownTimer;
    }

    private void Update()
    {
        ManipulateSlider();

        if(timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
        }

        if(timeRemaining <= 0f)
        {
            gameController.isGameOver = true;
        }
    }

    void ManipulateSlider()
    {
        timerSlider.value = CalculateSliderValue();
        ChangeSliderColor();
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / gameCountdownTimer);
    }

    void ChangeSliderColor()
    {
        if(timeRemaining <= 30f)
        {
            // Change the color of the slider fill area to orange.
            // TODO Try using Color.Lerp for the color changing effect.
            timerSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(255f,120f,0);
        }

        if (timeRemaining <= 10f)
        {
            // Change the color of the slider fill area to red.
            timerSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(255f, 0f, 0);
        }
    }
}

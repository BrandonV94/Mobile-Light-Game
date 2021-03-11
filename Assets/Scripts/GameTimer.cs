using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{   // TODO Make game audio go faster as time progresses.
    //AudioSource gameMusic = null;
    [SerializeField] Slider timerSlider = null;
    [SerializeField] float countdownTimer = 60f;
    [SerializeField] public float timeRemaining = 0f;

    private void Awake()
    {
        timerSlider = FindObjectOfType<Slider>();
        //gameMusic = FindObjectOfType<AudioSource>();
    }

    void Start()
    {
        timeRemaining = countdownTimer;
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
            GameController.isGameOver = true;
        }
    }

    void ManipulateSlider()
    {
        timerSlider.value = CalculateSliderValue();
        ChangeSliderColor();
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / countdownTimer);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    Slider timerSlider = null;
    RandomCubeGenerator rndCubeGenerator = null;
    [SerializeField] public float countdownTimer = 60f;
    [SerializeField] float timeRemaining = 0f;

    private void Awake()
    {
        timerSlider = FindObjectOfType<Slider>();
        rndCubeGenerator = GetComponent<RandomCubeGenerator>();
    }

    void Start()
    {
        timeRemaining = countdownTimer;
    }

    private void Update()
    {
        timerSlider.value = CalculateSliderValue();

        if(timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            rndCubeGenerator.gameObject.SetActive(false);
        }
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / countdownTimer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCube : MonoBehaviour
{
    GameController gameController = null;
    Light lightSource = null;
    [SerializeField] AudioSource lightAudioSource = null;
    [SerializeField] public bool isLightCubeOn = true;
    [SerializeField] public int pointsPerClick = 100;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        lightSource = GetComponentInChildren<Light>();
        lightAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckCubeLight();
    }

    private void OnMouseDown()
    {
        if (isLightCubeOn && GameController.isGameOver == false)
        {
            ProcessCubeClick();
        }
    }

    private void ProcessCubeClick()
    {
        if(GameController.isGamePaused == false)
        {
            TurnCubeLightOff();
            lightAudioSource.Play();
            IncrementScore(pointsPerClick);
        }
    }

    public void TurnCubeLightOff()
    {
        lightSource.gameObject.SetActive(false);
        isLightCubeOn = false;
    }

    public void TurnCubeLightOn()
    {
        lightSource.gameObject.SetActive(true);
        isLightCubeOn = true;
    }

    void CheckCubeLight()
    {
        if (lightSource.gameObject.activeSelf == true)
        {
            isLightCubeOn = true;
        }
        else
        {
            isLightCubeOn = false;
        }
    }

    public void IncrementScore(int pointsPerClick)
    {
        gameController.totalPoints += pointsPerClick;
    }
}

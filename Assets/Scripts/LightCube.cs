using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCube : MonoBehaviour
{
    GameController gameController = null;
    Light lightSource = null;
    [SerializeField] public bool isLightCubeOn = true;
    [SerializeField] int timeClicked = 0;
    [SerializeField] public int pointsPerClick = 100;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        lightSource = GetComponentInChildren<Light>();
    }

    void Update()
    {
        CheckCubeLight();
    }

    private void OnMouseDown()
    {
        if (isLightCubeOn)
        {
            TurnCubeLightOff();
            timeClicked++;
            incrementScore(pointsPerClick);
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

    public void incrementScore(int pointsPerClick)
    {
        gameController.totalPoints += pointsPerClick;
    }
}

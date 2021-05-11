using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightCube : MonoBehaviour
{
    GameController gameController = null;

    Light lightSource = null;
    TextMeshProUGUI pointDeductionText = null;
    [SerializeField] AudioSource lightAudioSource = null;

    [SerializeField] public bool isLightCubeOn = true;
    [SerializeField] public int pointsPerClick = 100;
    [SerializeField] int deductionPoints = 100;
    //[SerializeField] float deductionDelay = 1f;

    void Awake()
    {
        GetComponentsAndScripts();
    }

    private void Start()
    {
        pointDeductionText.enabled = false;
    }

    void Update()
    {
        CheckCubeLight();
        CheckIfPointsShouldBeDeducted();
    }

    private void OnMouseDown()
    {
        Debug.Log("Light Cube clicked.");
        if (isLightCubeOn && gameController.isGameOver == false)
        {
            ProcessCubeClick();
        }
    }

    private void ProcessCubeClick()
    {
        if(gameController.isGamePaused == false)
        {
            TurnCubeLightOff();
            lightAudioSource.Play();
            IncrementScore(pointsPerClick);
            Debug.Log("Light cube should have processed click...");
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

    void CheckIfPointsShouldBeDeducted()
    {
        if (gameController.isGameOver == true && isLightCubeOn == true)
        {
            pointDeductionText.enabled = true;
            DeductPointsForLight();
            Debug.Log("Points should be deducted accordingly.");

            Destroy(this);
        }
    }

    void DeductPointsForLight()
    {
        gameController.totalPoints -= deductionPoints;
        Debug.Log("Points have been deducted.");
    }

    private void GetComponentsAndScripts()
    {
        gameController = FindObjectOfType<GameController>();
        lightSource = GetComponentInChildren<Light>();
        lightAudioSource = GetComponent<AudioSource>();
        pointDeductionText = GetComponentInChildren<TextMeshProUGUI>();
    }
}

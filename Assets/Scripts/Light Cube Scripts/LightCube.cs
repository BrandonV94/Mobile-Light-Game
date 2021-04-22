using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightCube : MonoBehaviour
{
    GameController gameControllerScript = null;

    Light lightSource = null;
    TextMeshProUGUI pointDeductionText = null;
    [SerializeField] AudioSource lightAudioSource = null;

    [SerializeField] public bool isLightCubeOn = true;
    [SerializeField] public int pointsPerClick = 100;
    [SerializeField] int deductionPoints = 100;
    [SerializeField] float deductionDelay = 1f;

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
        gameControllerScript.totalPoints += pointsPerClick;
    }

    void CheckIfPointsShouldBeDeducted()
    {
        if (GameController.isGameOver == true && isLightCubeOn == true)
        {
            pointDeductionText.enabled = true;
            DeductPointsForLight();
            Debug.Log("Points should be deducted accordingly.");

            Destroy(this);
        }
    }

    void DeductPointsForLight()
    {
        gameControllerScript.totalPoints -= deductionPoints;
        Debug.Log("Points have been deducted.");
    }

    private void GetComponentsAndScripts()
    {
        gameControllerScript = FindObjectOfType<GameController>();
        lightSource = GetComponentInChildren<Light>();
        lightAudioSource = GetComponent<AudioSource>();
        pointDeductionText = GetComponentInChildren<TextMeshProUGUI>();
    }
}

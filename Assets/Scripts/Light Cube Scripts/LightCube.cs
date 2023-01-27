using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightCube : MonoBehaviour
{
    GameController gameController = null;

    Light lightSource = null;
    public GameObject bulbOn;
    public GameObject bulbOff;
    TextMeshProUGUI pointDeductionText = null;
    [SerializeField] AudioSource lightAudioSource = null;

    [SerializeField] public bool isLightCubeOn = true;
    [SerializeField] public int pointsPerClick = 100;
    [SerializeField] int deductionPoints = 100;

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
        if (isLightCubeOn && gameController.isGameOver == false && gameController.gameCountdownTimer == 0)
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
            ToggleBulbs();
        }
        else
        {
            isLightCubeOn = false;
            ToggleBulbs();
        }
    }

    void ToggleBulbs()
    {
        if(isLightCubeOn == true)
        {
            bulbOn.SetActive(true);
            bulbOff.SetActive(false);
        }
        else
        {
            bulbOn.SetActive(false);
            bulbOff.SetActive(true);
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

            Destroy(this);
        }
    }

    void DeductPointsForLight()
    {
        gameController.totalPoints -= deductionPoints;
    }

    private void GetComponentsAndScripts()
    {
        gameController = FindObjectOfType<GameController>();
        lightSource = GetComponentInChildren<Light>();
        lightAudioSource = GetComponent<AudioSource>();
        pointDeductionText = GetComponentInChildren<TextMeshProUGUI>();
    }
}

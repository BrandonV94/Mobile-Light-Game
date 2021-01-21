using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeGenerator : MonoBehaviour
{
    [SerializeField] GameTimer gameTimer = null;
    [SerializeField] GameController gameController = null;
    [SerializeField] float randomDelayTimer = 1f;

    private void Awake()
    {
        gameController = GetComponent<GameController>();
        gameTimer = GetComponent<GameTimer>();
    }

    void Start()
    {
        StartCoroutine(TurnLightsOnRandomly());
    }

    IEnumerator TurnLightsOnRandomly()
    {
        while(gameTimer.countdownTimer > 0)
        {
            gameController.TurnRandomCubeLightOn();
            yield return new WaitForSeconds(randomDelayTimer);
        }
    }
}

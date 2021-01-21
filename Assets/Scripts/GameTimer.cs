using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] GameController gameController = null;
    [SerializeField] public int countdownTimer = 60;

    private void Awake()
    {
        gameController = GetComponent<GameController>();
    }

    void Start()
    {
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (countdownTimer > 0)
        {
            //Debug.Log(countdownTimer);
            yield return new WaitForSeconds(1f);
            gameController.TurnRandomCubeLightOn();
            countdownTimer--;
        }
    }
}

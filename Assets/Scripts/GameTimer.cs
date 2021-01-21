using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] int gameTimer = 60;

    void Start()
    {
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (gameTimer > 0)
        {
            Debug.Log(gameTimer);
            yield return new WaitForSeconds(1f);
            gameTimer--;
        }
    }
}

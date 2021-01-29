using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    RandomCubeGenerator rndCubeGenerator = null;
    [SerializeField] public int countdownTimer = 60;

    private void Awake()
    {
        rndCubeGenerator = GetComponent<RandomCubeGenerator>();
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
            rndCubeGenerator.TurnRandomCubeLightOn();
            countdownTimer--;
        }
    }
}

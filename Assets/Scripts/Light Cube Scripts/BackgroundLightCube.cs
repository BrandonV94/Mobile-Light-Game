using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLightCube : MonoBehaviour
{
    [SerializeField] Light mylight = null;
    [SerializeField] float blinkDelay = 0f;
    [SerializeField] float toggleDelay = 1f;

    private void Awake()
    {
        mylight = GetComponentInChildren<Light>();
    }

    private void Start()
    {
        Invoke(nameof(BeginCoroutine), blinkDelay);
    }

    IEnumerator Blink()
    {
        while (true)
        {
            if (mylight.gameObject.activeInHierarchy == false)
            {
                mylight.gameObject.SetActive(true);
            }
            else
            {
                mylight.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(toggleDelay);
        }
    }

    private void BeginCoroutine()
    {
        StartCoroutine(Blink());
    }
}

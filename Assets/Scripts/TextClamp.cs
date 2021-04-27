using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextClamp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clampText;

    void Update()
    {
        Vector3 gameObjectPos = Camera.main.WorldToScreenPoint(this.transform.position);
        clampText.transform.position = gameObjectPos;
    }
}

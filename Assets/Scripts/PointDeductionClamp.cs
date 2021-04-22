using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointDeductionClamp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI deductionText;

    void Update()
    {
        Vector3 deductionPos = Camera.main.WorldToScreenPoint(this.transform.position);
        deductionText.transform.position = deductionPos;
    }
}

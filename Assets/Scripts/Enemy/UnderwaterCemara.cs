using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterCemara : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatAmount = 0.1f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = startPos + 
            new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatAmount, 0);
    }
}

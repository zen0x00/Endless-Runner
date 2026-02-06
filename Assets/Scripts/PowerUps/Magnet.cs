using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Magnet : MonoBehaviour
{
    public float duration = 5f;
    SphereCollider magnetCollider;

    void Start()
    {
        magnetCollider = GetComponentInChildren<SphereCollider>();
        magnetCollider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            StartCoroutine(MagnetRoutine());
            Destroy(other.gameObject);
        }
    }

    IEnumerator MagnetRoutine()
    {
        magnetCollider.enabled = true;
        yield return new WaitForSeconds(duration);
        magnetCollider.enabled = false;
    }
}

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    public float speed = 10f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MagnetArea"))
        {
            Transform player = other.transform.parent;

            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }
}


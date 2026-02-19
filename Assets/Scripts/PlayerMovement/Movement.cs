using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]float speed=5f;
    Rigidbody Rb;
    bool swimInput;
    void Start()
    {
        Rb=GetComponent<Rigidbody>();
    }
    void Update()
    {
        swimInput=Input.GetKey(KeyCode.W);
    }
    void FixedUpdate()
    {
        if (swimInput)
        {
            Vector3 forwardMove=transform.forward*speed*Time.fixedDeltaTime;
            Rb.MovePosition(Rb.position+forwardMove);
        }
    }
}
